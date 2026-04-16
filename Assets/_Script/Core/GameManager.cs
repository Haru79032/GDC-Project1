using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public ObjectPool pool;
    void OnEnable()
    {
        EventBroker.somethingIsShot += ReturnObject;
    }
    void OnDisable()
    {
        EventBroker.somethingIsShot -= ReturnObject;
    }

    void Start()
    {
        SpawnEnemy();
    }

    void Spawn()
    {
        float x = UnityEngine.Random.Range(-10, 10);
        float y = UnityEngine.Random.Range(-5, 5);

        GameObject obj = pool.GetObject();
        obj.transform.position = new Vector3(x, y, 0);
    }

    
    void ReturnObject(Collider2D obj)
    {
        pool.ReturnObject(obj.gameObject);
    }   

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(1f);
        }
    }
}       
