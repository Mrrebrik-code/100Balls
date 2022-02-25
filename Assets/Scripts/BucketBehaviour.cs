using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BucketBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Ease moveEase;

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
    public void CountHitBalls(BallSpawner ballSpawner)
    {
        ballSpawner.HitBallCount = 0;
        ballSpawner.HitBallCount++;
    }
}