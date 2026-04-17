using UnityEngine;

public class ShieldManager : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fragment") || collision.gameObject.CompareTag("Error"))
        {
            EventBroker.somethingIsBlocked?.Invoke(collision);
        }
    }
}
