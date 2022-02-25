using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BucketBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Ease moveEase;
    public delegate void TriggerHandler();
    public event TriggerHandler OnBucketHit;

    private void OnEnable()
    {
        OnBucketHit += CountHitBalls;
        OnBucketHit += ScoreView.Instance.AddScore;
        OnBucketHit += BallSpawner.Instance.SpawnCoroutine;
    }
    private void OnDisable()
    {
        OnBucketHit -= CountHitBalls;
        OnBucketHit -= ScoreView.Instance.AddScore;
        OnBucketHit -= BallSpawner.Instance.SpawnCoroutine;
    }
    private void Start()
    {
        speed = 5.0f;
        moveEase = Ease.Linear;
        Move();
    }
    private void Move()
    {
        transform
            .DOMoveX(-transform.position.x, speed)
            .OnComplete(DestroyBucket)
            .SetEase(moveEase);
    }
    private void DestroyBucket()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out BallBehaviour ballBehaviour))
        {
            ballBehaviour.transform.parent = gameObject.transform;
            Destroy(ballBehaviour.gameObject, 1.0f);
            OnBucketHit?.Invoke();
        }
    }
    private void CountHitBalls()
    {
        BallSpawner.Instance.HitBallCount = 0;
        BallSpawner.Instance.HitBallCount++;
    }
}