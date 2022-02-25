using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallCounter : MonoBehaviour
{
    private int count;
    [SerializeField] private BallSpawner ballSpawner;
    public delegate void CounterHandler();
    public event CounterHandler OnBallFalled;
    public static FallCounter Instance;

    private void Start()
    {
        OnBallFalled?.Invoke();
    }
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out BallBehaviour ballBehaviour))
        {
            if(ballSpawner.SummaryBallCount > 0)
            {
                ballSpawner.SpawnBallCount = 0;
                ballSpawner.SpawnBallCount++;
                OnBallFalled?.Invoke();
            }
        }
    }
}
