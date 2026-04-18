using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Collider2D myCollider;
    [SerializeField] private float defaultSpeed; 
    [SerializeField] private float maxSpeed;
    private float speed;
    private Vector2 targetPos;
    private bool isPaused = false;
    private bool isGameOver = false;
    void OnEnable()
    {
        EventBroker.onDifficultyEnhanced += EnhancingDifficulty;
        EventBroker.onGameOver += GameOver;
        EventBroker.onGamePaused += GameIsPaused;
    }

    void OnDisable()
    {
        EventBroker.onDifficultyEnhanced -= EnhancingDifficulty;
        EventBroker.onGameOver -= GameOver;
        EventBroker.onGamePaused -= GameIsPaused;
    }

    void Awake()
    {
        speed = defaultSpeed;
        targetPos = new Vector2(0, 0);
    }

    void Update()
    {
        if (isPaused || isGameOver)
        {
            return;
        }
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        if (transform.position == new Vector3(0, 0, 0))
        {
            EventBroker.onEnemyReachedTarget?.Invoke(myCollider);
        }
    }

    void EnhancingDifficulty()
    {
        if (speed < maxSpeed)
        {
            speed += (maxSpeed - defaultSpeed) / 20f;
        }
    }

    private void GameOver()
    {
        isGameOver = true;
    }

    private void GameIsPaused(bool state)
    {
        isPaused = state;
    }
}
