using UnityEngine;
using UnityEngine.SceneManagement;

public class StageHandler : MonoBehaviour
{
    [SerializeField] private BallSpawner ballSpawner;
    public static StageHandler Instance;

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }
    }
    public void SetRecordScore()
    {
        var ballCount = ballSpawner.BallList.Count;

        if (ballCount == 0)
        {
            UiView.Instance.ScoreHandler.SaveScore();
            SceneManager.LoadScene(0);
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}