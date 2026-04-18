using UnityEngine;

public class RandomPos
{
    private float _xRange;
    private float _yRange;
    
    public RandomPos(float xRange, float yRange)
    {
        _xRange = xRange;
        _yRange = yRange;
    }
    
    public Vector3 RandomOnPerimeter()
    {
        int side = Random.Range(0, 2); 
        
        float x, y;

        if (side == 0)
        {
            x = Random.Range(-_xRange, _xRange);
            y = Random.value > 0.5f ? _yRange : -_yRange;
        }
        
        else
        {
            x = Random.value > 0.5f ? _xRange : -_xRange;
            y = Random.Range(-_yRange, _yRange);
        }
        return new Vector3(x, y, 0f);
    }
}