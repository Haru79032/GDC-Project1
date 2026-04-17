using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed=2f;
    [SerializeField] private Collider2D myCollider;
    private Vector2 targetPos;

    void Start()
    {
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
}
