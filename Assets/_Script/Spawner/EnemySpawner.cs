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
    [SerializeField] private ObjectPool bugPool;
    [SerializeField] private ObjectPool errorPool;
    [SerializeField] private ObjectPool bombPool;
    [SerializeField] private float radius;
    [SerializeField] private float spawnTime = 3f;
    private bool IsSpawnReady=true;

    void OnEnable()
    {
        EventBroker.somethingIsShot += ReturnEnemy;
        EventBroker.onEnemyHitPlayer += ReturnEnemy;
        EventBroker.onEnemyReachedTarget += ReturnEnemy;
        EventBroker.somethingIsBlocked += ReturnEnemy;
    }

    void OnDisable()
    {
        EventBroker.somethingIsShot -= ReturnEnemy;
        EventBroker.onEnemyHitPlayer -= ReturnEnemy;
        EventBroker.onEnemyReachedTarget -= ReturnEnemy;
        EventBroker.somethingIsBlocked -= ReturnEnemy;
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
            int RandomNum = Random.Range(1, 101);
            GameObject enemy;
            if (RandomNum <= 60)
            {
                enemy = bugPool.GetObject();
            }
            else if (RandomNum > 60 && RandomNum <= 90)
            {
                enemy = errorPool.GetObject();
            }
            else
            {
                enemy = bombPool.GetObject();
            }
            enemy.transform.position=randomPos.RandomOnPerimeter();
            yield return new WaitForSeconds(spawnTime);
            IsSpawnReady=true;
        }
    }

    void ReturnEnemy(Collider2D collider)
    {
        if (!collider.gameObject.CompareTag("Fragment"))
        {
            if (collider.gameObject.CompareTag("Enemy"))
            {
                bugPool.ReturnObject(collider.gameObject);
            }
            else if (collider.gameObject.CompareTag("Enemy2"))
            {
                errorPool.ReturnObject(collider.gameObject);
            }
            else if (collider.gameObject.CompareTag("Enemy3"))
            {
                bombPool.ReturnObject(collider.gameObject);
            }
        }
    }
}
