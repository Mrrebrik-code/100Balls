using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public delegate void TriggerHandler();
    public event TriggerHandler OnFall;
    public event TriggerHandler OnHit;
    private BallSpawner ballSpawner;

    private void Awake()
    {
        var parent = transform.parent;
        ballSpawner = parent.GetComponent<BallSpawner>();
    }
    private void OnEnable()
    {
        OnHit += ScoreView.Instance.AddScore;
        OnHit += ballSpawner.HitBall;
        OnFall += ballSpawner.FallBall;
        OnFall += UiView.Instance.DisplayBallCount;
    }
    private void OnDisable()
    {
        OnHit -= ScoreView.Instance.AddScore;
        OnHit -= ballSpawner.HitBall;
        OnFall -= ballSpawner.FallBall;
        OnFall -= UiView.Instance.DisplayBallCount;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out BucketBehaviour bucket))
        {
            bucket.CountHitBalls(ballSpawner);
            transform.parent = bucket.transform;
            Destroy(gameObject, 1.0f);
            OnHit?.Invoke();
        }
        if (collision.TryGetComponent(out FallCounter fallCounter))
        {
            if (ballSpawner.SummaryBallCount > 0)
            {
                ballSpawner.SpawnBallCount = 0;
                ballSpawner.SpawnBallCount++;
                OnFall?.Invoke();
            }
            Destroy(gameObject, 1.0f);
        }
    }
}
