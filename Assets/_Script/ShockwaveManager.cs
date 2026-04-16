using System.Collections;
using UnityEngine;

public class ShockwaveManger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private ObjectPool shockwavePool;
    void OnEnable()
    {
        EventBroker.onBombDeath += CreateShockwave;
        EventBroker.onShockwaveHitSomething += ReturnShockwave;
    }
    void OnDisable()
    {
        EventBroker.onBombDeath -= CreateShockwave;
        EventBroker.onShockwaveHitSomething -= ReturnShockwave;
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CreateShockwave(Collider2D collider)
    {
        GameObject shockwave = shockwavePool.GetObject();
        shockwave.transform.position = collider.transform.position;
    }
    void ReturnShockwave(Collider2D collider)
    {
        shockwavePool.ReturnObject(collider.gameObject);
    }
   
}
