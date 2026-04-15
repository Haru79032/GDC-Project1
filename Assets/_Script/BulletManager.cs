using UnityEngine;
public class Bullet : MonoBehaviour
{
    [SerializeField] private Collider2D myCollider;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enemy is shot"); 
        EventBroker.onBulletHitSomething?.Invoke(myCollider);
        EventBroker.somethingIsShot?.Invoke(collision);
    }
}