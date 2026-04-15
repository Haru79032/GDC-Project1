using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject Enemy_Prefab;
    [SerializeField] private int Pool_Size=30;
    private Queue<GameObject> enemyPool;
    void Awake()
    {
        enemyPool=new Queue<GameObject>();
        for(int i=0;i<Pool_Size;i++)
        {
            GameObject enemy=Instantiate(Enemy_Prefab);
            enemy.SetActive(false);
            enemyPool.Enqueue(enemy);
        }
    }
    public GameObject GetEnemy()
    {
        if(enemyPool.Count>0)
        {
            GameObject enemy=enemyPool.Dequeue();
            enemy.SetActive(true);
            return enemy;
        }
        else
        {
            GameObject enemy=Instantiate(Enemy_Prefab);
            return enemy;
        }
    }
    public void ReturnEnemy(GameObject enemy)
    {
        enemy.SetActive(false);
        enemyPool.Enqueue(enemy);
    }  
}
