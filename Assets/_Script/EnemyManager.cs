using UnityEngine;
public class EnemyManager : MonoBehaviour
{
    private float speed;    
    public Vector2 targetPos;

    void Start()
    {
        targetPos = new Vector2(0f, 0f);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }
}