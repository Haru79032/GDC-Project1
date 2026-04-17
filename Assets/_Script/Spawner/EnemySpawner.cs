using System.Collections;
using System.Numerics;
using NUnit.Framework;
using Unity.VisualScripting;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private RandomPos randomPos;
    [SerializeField] private ObjectPool enemyPool;
    [SerializeField] private float radius;
    [SerializeField] private float spawnTime = 3f;
    private bool IsSpawnReady=true;

    void OnEnable()
    {
        EventBroker.somethingIsShot += ReturnEnemy;
        EventBroker.onEnemyHitPlayer += ReturnEnemy;
        EventBroker.onEnemyReachedTarget += ReturnEnemy;
    }

    void OnDisable()
    {
        EventBroker.somethingIsShot -= ReturnEnemy;
        EventBroker.onEnemyHitPlayer -= ReturnEnemy;
        EventBroker.onEnemyReachedTarget -= ReturnEnemy;
    }

    void Awake()
    {
        randomPos = new RandomPos(radius);
    }

    void Start()
    {
        StartCoroutine(Spawn_Enemy());
    }

    void Update()
    {        
        
    }
    IEnumerator Spawn_Enemy() {
        while (IsSpawnReady)
        {
            IsSpawnReady=false;
            GameObject enemy = enemyPool.GetObject();
            enemy.transform.position=randomPos.RandomOnPerimeter();
            yield return new WaitForSeconds(spawnTime);
            IsSpawnReady=true;
        }
    }

    void ReturnEnemy(Collider2D collider)
    {
        if (!collider.gameObject.CompareTag("Fragment"))
        {
            enemyPool.ReturnObject(collider.gameObject);
        }
    }
}
