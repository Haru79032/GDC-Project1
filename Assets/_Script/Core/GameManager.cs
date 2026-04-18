using NUnit.Framework;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float _difficultyEnhancingTime = 15.0f;
    [SerializeField] private Canvas deathCanvas;
    private bool isPaused = false;
    private bool isGameOver = false;
    private float _timer = 0.0f;

    void Awake()
    {
        Time.timeScale = 1f;
    }

    void OnEnable()
    {
        EventBroker.onGameOver += GameOver;
        EventBroker.onGamePaused += GameIsPaused;
    }

    void OnDisable()
    {
        EventBroker.onGameOver -= GameOver;
        EventBroker.onGamePaused -= GameIsPaused;
    }

    void Update()
    {
        if (isPaused || isGameOver)
        {
            return;
        }
        _timer += Time.deltaTime;
        if (_timer >= _difficultyEnhancingTime)
        {
            EventBroker.onDifficultyEnhanced?.Invoke();
            _timer = 0.0f;
        }
    }

    void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0.0f;
        if (deathCanvas != null)
        {
            deathCanvas.gameObject.SetActive(true);
        }
    }

    private void GameIsPaused(bool state)
    {
        isPaused = state;
    }
}       
