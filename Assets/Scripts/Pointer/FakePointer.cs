using UnityEngine;
using UnityEngine.InputSystem;

public class FakePointer : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
        gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPos.x, mouseScreenPos.y, Camera.main.nearClipPlane));   
    }
}