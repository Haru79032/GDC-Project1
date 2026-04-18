using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private RandomPos randomPos;
    [SerializeField] private ObjectPool bugPool;
    [SerializeField] private ObjectPool errorPool;
    [SerializeField] private ObjectPool bombPool;
    [SerializeField] private float radius;
    [SerializeField] private float defaultSpawnTime;
    private float spawnTime;
    private bool IsSpawnReady=true;

    void OnEnable()
    {
        EventBroker.somethingIsShot += ReturnEnemy;
        EventBroker.onEnemyHitPlayer += ReturnEnemy;
        EventBroker.onEnemyReachedTarget += ReturnEnemy;
        EventBroker.somethingIsBlocked += ReturnEnemy;
        EventBroker.onDifficultyEnhanced += EnhancingDifficulty;
    }

    void OnDisable()
    {
        EventBroker.somethingIsShot -= ReturnEnemy;
        EventBroker.onEnemyHitPlayer -= ReturnEnemy;
        EventBroker.onEnemyReachedTarget -= ReturnEnemy;
        EventBroker.somethingIsBlocked -= ReturnEnemy;
        EventBroker.onDifficultyEnhanced -= EnhancingDifficulty;
    }

    void Awake()
    {
        randomPos = new RandomPos(radius);
        spawnTime = defaultSpawnTime;
    }

    void Start()
    {
        StartCoroutine(Spawn_Enemy());
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
        if (collider.gameObject.CompareTag("Bug"))
        {
            bugPool.ReturnObject(collider.gameObject);
        }
        else if (collider.gameObject.CompareTag("Error"))
        {
            errorPool.ReturnObject(collider.gameObject);
        }
        else if (collider.gameObject.CompareTag("Bomb"))
        {
            bombPool.ReturnObject(collider.gameObject);
        }
    }

    void EnhancingDifficulty()
    {
        if (spawnTime > 0.25f) spawnTime -= 0.25f;
    }
}
