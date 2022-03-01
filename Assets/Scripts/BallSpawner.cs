using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private Transform leftSpawnPoint;
    [SerializeField] private Transform rightSpawnPoint;
    [SerializeField] private GameObject spawnObject;
    private enum SpawnSide
    {
        Left,
        Right
    }
    private int summaryBallCount = 100;
    private int startBallCount = 16;
    private List<BallBehaviour> ballList = new List<BallBehaviour>();
    public int SummaryBallCount { get { return summaryBallCount; } set { summaryBallCount = value; } }
    public List<BallBehaviour> BallList { get { return ballList; } set { ballList = value; } }

    public void SpawnBalls()
    {
        StartCoroutine(SpawnCoroutine());
    }
    public void CheckBallCount()
    {
        var ballCount = ballList.Count;

        if (ballCount == 0)
        {
            ScoreView.Instance.SaveScore();
        }
    }
    IEnumerator SpawnCoroutine()
    {
        for (int i = 0; i < startBallCount; i++)
        {
            summaryBallCount--;

            var spawnPointNum = i % 2;
            var spawnSide = (SpawnSide)spawnPointNum;

            var ballObject = Instantiate(spawnObject, transform);
            var ball = ballObject.GetComponent<BallBehaviour>();
            ballList.Add(ball);

            if (spawnSide == SpawnSide.Left)
            {
                ballObject.transform.position = leftSpawnPoint.position;
            }
            else
            {
                ballObject.transform.position = rightSpawnPoint.position;
            }

            UiView.Instance.DisplayBallCount();
            yield return new WaitForSeconds(0.2f);
        }
    }
}