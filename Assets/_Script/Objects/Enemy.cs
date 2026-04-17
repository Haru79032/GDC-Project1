using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float defaultSpeed; 
    [SerializeField] private Collider2D myCollider;
    private float speed;
    private Vector2 targetPos;

    void OnEnable()
    {
        EventBroker.OnDifficultyEnhanced += EnhancingDifficulty;
    }

    void OnDisable()
    {
        EventBroker.OnDifficultyEnhanced -= EnhancingDifficulty;
    }

    void Awake()
    {
        speed = defaultSpeed;
        targetPos = new Vector2(0, 0);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        if (transform.position == new Vector3(0, 0, 0))
        {
            EventBroker.onEnemyReachedTarget?.Invoke(myCollider);
        }
    }

    void EnhancingDifficulty()
    {
        speed += 0.25f;
    }
}
