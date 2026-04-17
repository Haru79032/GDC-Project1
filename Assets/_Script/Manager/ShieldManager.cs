using UnityEngine;

public class ShieldManager : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fragment") || collision.gameObject.CompareTag("Enemy2"))
        {
            EventBroker.somethingIsBlocked?.Invoke(collision);
        }
    }
}
