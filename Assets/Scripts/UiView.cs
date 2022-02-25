using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiView : MonoBehaviour
{
    [SerializeField] private FallCounter fallCounter;
    [SerializeField] private BallSpawner ballSpawner;
    [SerializeField] private Text ballCountText;
    [SerializeField] private Text scoreText;

    private void OnEnable()
    {
        fallCounter.OnBallFalled += DisplayBallCount;
        ScoreView.Instance.OnScoreUpdate += DisplayScore;
    }
    private void OnDisable()
    {
        fallCounter.OnBallFalled -= DisplayBallCount;
        ScoreView.Instance.OnScoreUpdate -= DisplayScore;
    }
    private void DisplayBallCount()
    {
        var ballCount = ballSpawner.SummaryBallCount;
        ballCountText.text = ballCount.ToString();
    }
    private void DisplayScore()
    {
        var score = ScoreView.Instance.Score;
        scoreText.text = score.ToString();
    }
}
