using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    private int score;
    public int Score { get { return score; } }
    public delegate void CounterHandler();
    public event CounterHandler OnScoreUpdate;

    public void AddScore(int receiveScore)
    {
        score += receiveScore;
        OnScoreUpdate?.Invoke();
    }
    public void SaveScore()
    {
        var recordScore = PlayerPrefs.GetInt("Score");

        if (recordScore < score)
        {
            PlayerPrefs.SetInt("Score", score);
        }
    }
}
