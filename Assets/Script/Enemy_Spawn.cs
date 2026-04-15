using System.Collections;
using System.Numerics;
using NUnit.Framework;
using Unity.VisualScripting;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private RandomPos randomPos;
    [SerializeField] private ObjectPool enemyPool;
    [SerializeField] private float xRange;
    [SerializeField] private float yRange;
    [SerializeField] private float spawnTime = 3f;
    private bool IsSpawnReady=true;

    void OnEnable()
    {
        EventBroker.somethingIsShot += ReturnObject;
    }

    void OnDisable()
    {
        EventBroker.somethingIsShot -= ReturnObject;
    }

    void Awake()
    {
        randomPos = new RandomPos(xRange, yRange);
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

    void ReturnObject(Collider2D collider)
    {
        enemyPool.ReturnObject(collider.gameObject);
    }
}
