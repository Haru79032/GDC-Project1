using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float Speed=2f;
    UnityEngine.Vector3 direction;
    private EnemyPool enemyPool;
    void Start()
    {
        enemyPool = FindAnyObjectByType<EnemyPool>();
        direction = (UnityEngine.Vector3.zero - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * Speed * Time.deltaTime;
    }
    public void ReturnToPool()
    {
        if (enemyPool != null)
            enemyPool.ReturnEnemy(gameObject);
    }
    void OnBecameInvisible()
    {
        ReturnToPool();
    }
    void OnBecameVisible()
    {
        direction = (UnityEngine.Vector3.zero - transform.position).normalized;
    }
}
