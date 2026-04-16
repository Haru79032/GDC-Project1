using UnityEngine;

public class ShieldManager : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fragment"))
        {
            Debug.Log("Shield blocked something");
            EventBroker.somethingIsBlocked?.Invoke(collision);
        }
    }
}
