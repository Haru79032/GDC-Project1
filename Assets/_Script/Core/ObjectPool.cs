using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject prefab;
    [SerializeField] private int Pool_Size=30;
    private Queue<GameObject> pool;
    void Awake()
    {
        pool=new Queue<GameObject>();
        for(int i=0;i<Pool_Size;i++)
        {
            GameObject enemy=Instantiate(prefab);
            enemy.SetActive(false);
            pool.Enqueue(enemy);
        }
    }
    public GameObject GetObject()
    {
        if(pool.Count>0)
        {
            GameObject enemy=pool.Dequeue();
            enemy.SetActive(true);
            return enemy;
        }
        else
        {
            GameObject enemy=Instantiate(prefab);
            return enemy;
        }
    }
    public void ReturnObject(GameObject enemy)
    {
        enemy.SetActive(false);
        pool.Enqueue(enemy);
    }  
}
