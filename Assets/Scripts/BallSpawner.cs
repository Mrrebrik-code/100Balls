using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private Transform leftSpawnPoint;
    [SerializeField] private Transform rightSpawnPoint;
    [SerializeField] private GameObject spawnObject;
    [SerializeField] private FallCounter fallCounter;
    private enum SpawnSide
    {
        Left,
        Right
    }
    private int summaryBallCount = 100;
    private int spawnBallCount = 16;
    private int hitBallCount;
    public int SpawnBallCount { get { return spawnBallCount; } set { spawnBallCount = value; } }
    public int SummaryBallCount { get { return summaryBallCount; } set { summaryBallCount = value; } }
    public int HitBallCount { get { return hitBallCount; } set { hitBallCount = value; } }
    public static BallSpawner Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    private void OnEnable()
    {
        fallCounter.OnBallFalled += SubstractBallCount;
    }
    private void OnDisable()
    {
        fallCounter.OnBallFalled -= SubstractBallCount;
    }
    private void SubstractBallCount()
    {
        summaryBallCount -= spawnBallCount;
        StartCoroutine(FallBallCoroutine());
    }
    public void SpawnCoroutine()
    {
        StartCoroutine(HitBallCoroutine());
    }
    private void SpawnObject()
    {
        var randomNumber = Random.Range(0, 2);
        var spawnSide = (SpawnSide)randomNumber;

        if (spawnSide == SpawnSide.Left) Instantiate(spawnObject, leftSpawnPoint);
        else Instantiate(spawnObject, rightSpawnPoint);
    }
    IEnumerator FallBallCoroutine()
    {
        for (int i = 0; i < spawnBallCount; i++)
        {
            yield return new WaitForSeconds(0.2f);
            SpawnObject();
        }
    }
    IEnumerator HitBallCoroutine()
    {
        for (int i = 0; i < hitBallCount; i++)
        {
            yield return new WaitForSeconds(0.2f);
            SpawnObject();
        }
    }
}