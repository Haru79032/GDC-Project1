using UnityEngine;

public class EnemyFragment : MonoBehaviour
{
    [SerializeField] private Collider2D myCollider;
    void OnBecameInvisible()
    {
        EventBroker.onFragmentOutOfScreen?.Invoke(myCollider);
    }
}
