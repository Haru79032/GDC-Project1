using UnityEngine;

public class RandomPos : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float Spawn_XRange=10;
    [SerializeField] private float Spawn_YRange=4;
    public Vector3 RandomOnPerimeter()
    {
        Vector3 randomPos = UnityEngine.Vector3.zero;
        int RandomSpawn=UnityEngine.Random.Range(1,3);
        if (RandomSpawn == 1)
        {
            randomPos= new Vector3(UnityEngine.Random.Range(-Spawn_XRange, Spawn_XRange), UnityEngine.Random.value > 0.5f ? Spawn_YRange : -Spawn_YRange, 0);
        }
        else if (RandomSpawn == 2)
        {
            randomPos= new Vector3(UnityEngine.Random.value > 0.5f ? Spawn_XRange : -Spawn_XRange, UnityEngine.Random.Range(-Spawn_YRange, Spawn_YRange), 0);
        }
        return randomPos;
    }
}
