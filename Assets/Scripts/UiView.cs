using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiView : MonoBehaviour
{
    [SerializeField] private BallSpawner ballSpawner;
    [SerializeField] private Text ballCountText;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text recordText;
    [SerializeField] private Image firstPanel;
    [SerializeField] private Image gamePanel;
    public static UiView Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    private void Start()
    {
        var recordScore = PlayerPrefs.GetInt("Score");
        recordText.text = recordScore.ToString();
    }
    private void OnEnable()
    {
        ScoreView.Instance.OnScoreUpdate += DisplayScore;
    }
    private void OnDisable()
    {
        ScoreView.Instance.OnScoreUpdate -= DisplayScore;
    }
    public void DisplayBallCount()
    {
        var ballCount = ballSpawner.SummaryBallCount;
        ballCountText.text = ballCount.ToString();
    }
    private void DisplayScore()
    {
        var score = ScoreView.Instance.Score;
        scoreText.text = score.ToString();
    }
    public void Play()
    {
        firstPanel.gameObject.SetActive(false);
        gamePanel.gameObject.SetActive(true);
        ballCountText.gameObject.SetActive(true);
        ballSpawner.SpawnBalls();
    }
}
