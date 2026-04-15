using UnityEngine;

public class RandomPos
{
    private float _spawn_XRange;
    private float _spawn_YRange;
    
    public RandomPos(float Spawn_XRange, float Spawn_YRange)
    {
        _spawn_XRange = Spawn_XRange;
        _spawn_YRange = Spawn_YRange;
    }
    
    public Vector3 RandomOnPerimeter()
    {
        Vector3 randomPos = UnityEngine.Vector3.zero;
        int RandomSpawn=UnityEngine.Random.Range(1,3);
        if (RandomSpawn == 1)
        {
            randomPos= new Vector3(UnityEngine.Random.Range(-_spawn_XRange, _spawn_XRange), UnityEngine.Random.value > 0.5f ? _spawn_YRange : -_spawn_YRange, 0);
        }
        else if (RandomSpawn == 2)
        {
            randomPos= new Vector3(UnityEngine.Random.value > 0.5f ? _spawn_XRange : -_spawn_XRange, UnityEngine.Random.Range(-_spawn_YRange, _spawn_YRange), 0);
        }
        return randomPos;
    }
}
