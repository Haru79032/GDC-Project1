using UnityEngine;
public class Bullet : MonoBehaviour
{
    [SerializeField] private Collider2D myCollider;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy is shot");
            EventBroker.onBulletHitSomething?.Invoke(myCollider);
            EventBroker.somethingIsShot?.Invoke(collision);
        }
        if (collision.gameObject.CompareTag("Enemy3")){
            Debug.Log("Bomb is shot");
            EventBroker.onBombDeath?.Invoke(myCollider);
            EventBroker.somethingIsShot?.Invoke(collision);
            
        }
    }
    void OnBecameInvisible()
    {
        EventBroker.onBulletHitSomething?.Invoke(myCollider);
    }
}