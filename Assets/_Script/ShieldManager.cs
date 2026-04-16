using UnityEngine;

public class ShieldManager : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy2"))
        {
            Debug.Log("Shield blocked an enemy");
            EventBroker.somethingIsShot?.Invoke(collision);
        }
    }
}
