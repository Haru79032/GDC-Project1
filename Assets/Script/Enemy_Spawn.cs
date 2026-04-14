using System.Collections;
using System.Numerics;
using NUnit.Framework;
using Unity.VisualScripting;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private RandomPos randomPos;
    [SerializeField] private EnemyPool enemyPool;
    [SerializeField] private float Spaww_Rate=3f;
    private bool IsSpawnReady=true;
    void Start(){}

    // Update is called once per frame
    void Update()
    {        if(IsSpawnReady)
        StartCoroutine(Spawn_Enemy());
    }
    IEnumerator Spawn_Enemy(){
        IsSpawnReady=false;
        GameObject enemy=enemyPool.GetEnemy();
        enemy.transform.position=randomPos.RandomOnPerimeter();
        yield return new WaitForSeconds(Spaww_Rate);
        IsSpawnReady=true;
    }


}
