using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float _difficultyEnhancingTime = 15f;
    private float _timer = 0f;

    void Awake()
    {
        Time.timeScale = 1f;
    }

    void OnEnable()
    {
        EventBroker.onGameOver += GameOver;
    }

    void OnDisable()
    {
        EventBroker.onGameOver -= GameOver;
    }

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _difficultyEnhancingTime)
        {
            EventBroker.OnDifficultyEnhanced?.Invoke();
            _timer = 0f;
        }
    }

    void GameOver()
    {
        Time.timeScale = 0f;
    }
}       
