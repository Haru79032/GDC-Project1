using UnityEngine;

public class RandomPos
{
    private float _radius;
    
    public RandomPos(float radius)
    {
        _radius = radius;
    }
    
    public Vector3 RandomOnPerimeter()
    {
        Vector2 randomPoint = Random.insideUnitCircle.normalized * _radius;
        
        return new Vector3(randomPoint.x, randomPoint.y, 0f);
    }
}