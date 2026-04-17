using TMPro;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    private float[] streakMilestone = new float[5] {60, 45, 30, 20, 10};
    private int[] comboMilestone = new int[5] {100, 80, 60, 40, 20};
    private float[] scoreMultiplier = new float[5] {6, 5, 4, 3, 2};
    
    private float _highestScore;
    private float _currentScore;
    private float _timer;
    
    private float _streakMultiplier;
    private float _streakTimer;
    
    private int _comboCount;
    private float _comboMultiplier;

    void OnEnable()
    {
        EventBroker.somethingIsBlocked += addComboScore;
        EventBroker.somethingIsShot += addComboScore;
        EventBroker.onEnemyHitPlayer += resetStreakAndCombo;
    }

    void OnDisable()
    {
        EventBroker.somethingIsBlocked -= addComboScore;
        EventBroker.somethingIsShot -= addComboScore;
        EventBroker.onEnemyHitPlayer -= resetStreakAndCombo;
    }

    void Awake()
    {
        _currentScore = 0;
        _streakMultiplier = 1f;
        _comboMultiplier = 1f;
        _scoreText.text = $"Score: {_currentScore}";
        _highestScore = PlayerPrefs.GetFloat("HighestScore", 0f);
    }

    void Update()
    {
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
        _streakMultiplier = 1f;
        _comboCount = 0;
        _comboMultiplier = 1f;
    }

    void UpdateScore(float Score)
    {
        _currentScore += Score;
        if (_currentScore > _highestScore) _highestScore = _currentScore;
        _scoreText.text = $"Score: {_currentScore}";
    }

    void GameOver()
    {
        PlayerPrefs.SetFloat("HighestScore", _highestScore);
    }
}
