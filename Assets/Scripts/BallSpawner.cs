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

    public void FallBall()
    {
        StartCoroutine(FallCoroutine());
    }
    public void HitBall()
    {
        StartCoroutine(HitCoroutine());
    }
    private void SpawnObject()
    {
        var randomNumber = Random.Range(0, 2);
        var spawnSide = (SpawnSide)randomNumber;

        var ball = Instantiate(spawnObject, transform);

        if (spawnSide == SpawnSide.Left)
        {
            ball.transform.position = leftSpawnPoint.position;
        }
        else
        {
            ball.transform.position = rightSpawnPoint.position;
        }
    }
    IEnumerator FallCoroutine()
    {
        summaryBallCount -= spawnBallCount;

        for (int i = 0; i < spawnBallCount; i++)
        {
            yield return new WaitForSeconds(0.2f);
            SpawnObject();
        }
    }
    IEnumerator HitCoroutine()
    {
        for (int i = 0; i < hitBallCount; i++)
        {
            yield return new WaitForSeconds(0.2f);
            SpawnObject();
        }
    }
}