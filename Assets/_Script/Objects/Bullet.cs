using UnityEngine;
public class Bullet : MonoBehaviour
{
    [SerializeField] private Collider2D myCollider;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        EventBroker.onBulletHitSomething?.Invoke(myCollider);

        if (collision.gameObject.CompareTag("Enemy"))
        {
            EventBroker.somethingIsShot?.Invoke(collision);
        }

        if (collision.gameObject.CompareTag("Enemy3")) {
            EventBroker.onBombDeath?.Invoke(collision.transform.position);
            EventBroker.somethingIsShot?.Invoke(collision);    
        }
    }
    void OnBecameInvisible()
    {
        EventBroker.onBulletHitSomething?.Invoke(myCollider);
    }
}