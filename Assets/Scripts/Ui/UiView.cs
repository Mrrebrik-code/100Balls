using UnityEngine;
using UnityEngine.UI;

public class UiView : MonoBehaviour
{
    [SerializeField] private BallSpawner ballSpawner;
    [SerializeField] private Text ballCountText;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text recordText;
    [SerializeField] private Image firstPanel;
    [SerializeField] private Image pausePanel;
    [SerializeField] private Image gamePanel;
    [SerializeField] private Image gameNameEnglish;
    [SerializeField] private Image recordEnglish;
    [SerializeField] private Image scoreEnglish;
    [SerializeField] private Image gameNameRussian;
    [SerializeField] private Image recordRussian;
    [SerializeField] private Image scoreRussian;
    [SerializeField] private Image soundImage;
    [SerializeField] private Sprite soundOnSprite;
    [SerializeField] private Sprite soundOffSprite;
    private enum Sound
    {
        On,
        Off
    }
    private enum Language
    {
        Russian,
        English
    }
    private Language language = Language.Russian;
    private Sound sound = Sound.On;
    public static UiView Instance;
    public ScoreHandler ScoreHandler { get; set; }

    private void Awake()
    {
        ScoreHandler = GetComponent<ScoreHandler>();
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    private void Start()
    {
        var recordScore = PlayerPrefs.GetInt("Score");
        language = (Language)PlayerPrefs.GetInt("Language");
        sound = (Sound)PlayerPrefs.GetInt("Sound");
        recordText.text = recordScore.ToString();
        SetLanguage();
        SetSound();
    }
    private void OnEnable()
    {
        ScoreHandler.OnScoreUpdate += DisplayScore;
    }
    private void OnDisable()
    {
        ScoreHandler.OnScoreUpdate -= DisplayScore;
    }
    public void DisplayBallCount()
    {
        var ballCount = ballSpawner.SummaryBallCount;
        ballCountText.text = ballCount.ToString();
    }
    private void DisplayScore()
    {
        var score = ScoreHandler.Score;
        scoreText.text = score.ToString();
    }
    public void ClickPlayButton()
    {
        firstPanel.gameObject.SetActive(false);
        gamePanel.gameObject.SetActive(true);
        ballCountText.gameObject.SetActive(true);
        ballSpawner.SpawnBalls();
    }
    public void ClickLanguageButton()
    {
        var languageBool = language == Language.Russian;
        language = languageBool ? Language.English : Language.Russian;
        var langNum = (int)language;

        SetLanguage();
        PlayerPrefs.SetInt("Language", langNum);
    }
    public void ClickSoundButton()
    {
        var soundBool = sound == Sound.On;
        sound = soundBool ? Sound.Off : Sound.On;
        var soundNum = (int)sound;

        SetSound();
        PlayerPrefs.SetInt("Sound", soundNum);
    }
    public void ClickPauseButton()
    {
        gamePanel.gameObject.SetActive(false);
        pausePanel.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void ClickContinueButton()
    {
        gamePanel.gameObject.SetActive(true);
        pausePanel.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void ClickRestartButton()
    {
        StageHandler.Instance.Restart();
        Time.timeScale = 1;
    }
    private void SetLanguage()
    {
        if (language == Language.Russian)
        {
            gameNameRussian.gameObject.SetActive(true);
            recordRussian.gameObject.SetActive(true);
            scoreRussian.gameObject.SetActive(true);
            gameNameEnglish.gameObject.SetActive(false);
            recordEnglish.gameObject.SetActive(false);
            scoreEnglish.gameObject.SetActive(false);
        }
        else
        {
            gameNameRussian.gameObject.SetActive(false);
            recordRussian.gameObject.SetActive(false);
            scoreRussian.gameObject.SetActive(false);
            gameNameEnglish.gameObject.SetActive(true);
            recordEnglish.gameObject.SetActive(true);
            scoreEnglish.gameObject.SetActive(true);
        }
    }
    private void SetSound()
    {
        if (sound == Sound.On)
        {
            soundImage.sprite = soundOnSprite;
        }
        else
        {
            soundImage.sprite = soundOffSprite;
        }
    }
}
