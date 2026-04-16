using UnityEngine;

public class FragmentManager : MonoBehaviour
{
    [SerializeField] private ObjectPool fragmentPool;
    [SerializeField] private float explosionForce;
    
    private readonly Vector2[] explodeDirections = new Vector2[8]
    {
        new Vector2(0, 1).normalized,
        new Vector2(1, 0).normalized,
        new Vector2(1, 1).normalized,
        new Vector2(1, -1).normalized,
        new Vector2(0, -1).normalized,
        new Vector2(-1, -1).normalized,
        new Vector2(-1, 0).normalized,
        new Vector2(-1, 1).normalized,
    }; 

    void OnEnable()
    {
        EventBroker.onBombDeath += Explode;
        EventBroker.onFragmentOutOfScreen += returnFragment;
        EventBroker.somethingIsBlocked += returnFragment;
    }
    void OnDisable()
    {
        EventBroker.onBombDeath -= Explode;
        EventBroker.onFragmentOutOfScreen -= returnFragment;
        EventBroker.somethingIsBlocked -= returnFragment;
    }

    public void Explode(Vector3 position)
    {
        foreach (Vector2 direction in explodeDirections)
        {
            GameObject frag = fragmentPool.GetObject();
            
            frag.transform.position = position;

            Rigidbody2D rb = frag.GetComponent<Rigidbody2D>();

            if (rb != null) rb.linearVelocity = direction * explosionForce;
        }
    }
    
    void returnFragment(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Fragment"))
        {
            fragmentPool.ReturnObject(collider.gameObject);
        } 
    }
}

