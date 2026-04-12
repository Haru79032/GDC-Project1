using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject player;
    public float speed=5f;
    void Awake()
    {
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && player.transform.position.y < 0)
        {
            player.GetComponent<Rigidbody2D>().linearVelocity = new Vector3(0, speed*Time.deltaTime*250, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            player.transform.position += new Vector3(speed*Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            player.transform.position += new Vector3(-speed*Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            player.GetComponent<Rigidbody2D>().linearVelocity += new Vector2(0, -speed*Time.deltaTime);
        }
        if (Mathf.Abs(player.transform.position.x) > 10.74f )
        {
            player.transform.position = new Vector3(-player.transform.position.x, player.transform.position.y, player.transform.position.z);
        }
    }     
}
