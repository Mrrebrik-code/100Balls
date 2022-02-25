using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    public static ScoreView Instance;
    private int score;
    public int Score { get { return score; } }
    public delegate void ScoreHandler();
    public event ScoreHandler OnScoreUpdate;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    public void AddScore()
    {
        score++;
        OnScoreUpdate?.Invoke();
    }
}
