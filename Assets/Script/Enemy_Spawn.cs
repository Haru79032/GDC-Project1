using System.Collections;
using System.Numerics;
using NUnit.Framework;
using Unity.VisualScripting;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject Enemy_Prefab;
    [SerializeField] private float Spawn_XRange=10;
    [SerializeField] private float Spawn_YRange=4;
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
        UnityEngine.Vector3 randomPos = UnityEngine.Vector3.zero;
        int RandomSpawn=Random.Range(1,3);
        if (RandomSpawn == 1)
        {
            randomPos= new UnityEngine.Vector3(Random.Range(-Spawn_XRange, Spawn_XRange), Random.value > 0.5f ? Spawn_YRange : -Spawn_YRange, 0);
        }
        else if (RandomSpawn == 2)
        {
            randomPos= new UnityEngine.Vector3(Random.value > 0.5f ? Spawn_XRange : -Spawn_XRange, Random.Range(-Spawn_YRange, Spawn_YRange), 0);
        }
        Instantiate(Enemy_Prefab,randomPos,UnityEngine.Quaternion.identity);
        yield return new WaitForSeconds(Spaww_Rate);
        IsSpawnReady=true;
    }


}
