using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _finalScoreText;
    [SerializeField] private TextMeshProUGUI _highScoreText;
    private float[] streakMilestone = new float[5] {60.0f, 45.0f, 30.0f, 20.0f, 10.0f};
    private int[] comboMilestone = new int[5] {100, 80, 60, 40, 20};
    private int[] scoreMultiplier = new int[5] {6, 5, 4, 3, 2};
    
    private int _highestScore;
    private int _currentScore;
    private float _timer;
    
    private int _streakMultiplier;
    private float _streakTimer;
    
    private int _comboCount;
    private int _comboMultiplier;
    private const int MIN_SCORE = 0;
    private const int MAX_SCORE = 999999999;
    private bool isPaused = false;
    private bool isGameOver = false;

    void OnEnable()
    {
        EventBroker.somethingIsBlocked += addComboScore;
        EventBroker.somethingIsShot += addComboScore;
        EventBroker.onEnemyHitPlayer += resetStreakAndCombo;
        EventBroker.onGameOver += GameOver;
        EventBroker.onGamePaused += GameIsPaused;
    }

    void OnDisable()
    {
        EventBroker.somethingIsBlocked -= addComboScore;
        EventBroker.somethingIsShot -= addComboScore;
        EventBroker.onEnemyHitPlayer -= resetStreakAndCombo;
        EventBroker.onGameOver -= GameOver;
        EventBroker.onGamePaused -= GameIsPaused;
    }

    void Awake()
    {
        _currentScore = 0;
        _streakMultiplier = 1;
        _streakTimer = 0f;
        _comboMultiplier = 1;
        _comboCount = 0;
        _highestScore = PlayerPrefs.GetInt("HighestScore", 0);
    }

    void Update()
    {
        if (isPaused || isGameOver)
        {
            return;
        }
        _timer += Time.deltaTime;
        _streakTimer += Time.deltaTime;

        if (_timer >= 1)
        {
            StreakManage();
            addBasicScore();
        }
    }

    void addBasicScore()
    {
        _timer = 0;
        UpdateScore(_streakMultiplier);
    }

    void StreakManage()
    {
        int idx = 0;
        foreach (float milestone in streakMilestone)
        {
            if (_streakTimer >= milestone)
            {
                _streakMultiplier = scoreMultiplier[idx];
                break;
            }
            idx++; 
        }
    }

    void ComboManage()
    {
        int idx = 0;
        foreach(int milestone in comboMilestone)
        {
            if (_comboCount >= milestone)
            {
                _comboMultiplier = scoreMultiplier[idx];
                break;
            }
            idx++;
        }
    }

    void addComboScore(Collider2D collider)
    {
        _comboCount++;
        ComboManage();
        UpdateScore(_comboMultiplier);
    }

    void resetStreakAndCombo(Collider2D collider)
    {
        _streakTimer = 0f;
        _streakMultiplier = 1;
        _comboCount = 0;
        _comboMultiplier = 1;
    }

    void UpdateScore(int score)
    {
        _currentScore += score;
        _currentScore = Mathf.Clamp(_currentScore, MIN_SCORE, MAX_SCORE);
        if (_scoreText != null)
        {
            _scoreText.text = _currentScore.ToString("D9");
        }
    }

    void GameOver()
    {
        isGameOver = true;
        if (_currentScore > _highestScore)
        {
            _highestScore = _currentScore;
            PlayerPrefs.SetInt("HighestScore", _highestScore);
            PlayerPrefs.Save();
        }

        if (_finalScoreText != null)
        {
            _finalScoreText.SetText("Score: {0}", _currentScore);
        }
        if (_highScoreText != null)
        {
            _highScoreText.SetText("Hi-score: {0}", _highestScore);
        }
    }

    private void GameIsPaused(bool state)
    {
        isPaused = state;
    }
}
