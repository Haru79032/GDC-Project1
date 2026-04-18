using UnityEngine;
using UnityEngine.InputSystem;

public class OrbitManager : MonoBehaviour
{
    [SerializeField] private GameObject _gun;
    
    [SerializeField] private GameObject _shield;
    public Camera mainCamera;
    private bool isPaused = false;
    private bool isGameOver = false;
    void OnEnable()
    {
        EventBroker.onGameOver += GameOver;
        EventBroker.onGamePaused += GameIsPaused;
    }

    void OnDisable()
    {
        EventBroker.onGameOver -= GameOver;
        EventBroker.onGamePaused -= GameIsPaused;
    }

    void Update()
    {
        if (Mouse.current == null || isPaused || isGameOver) return;
        
        Vector2 mouseScreenPos = Mouse.current.position.ReadValue();

        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(new Vector3(mouseScreenPos.x,
                                                                            mouseScreenPos.y,
                                                                            mainCamera.nearClipPlane));

        mouseWorldPos.z = 0f;

        Vector3 direction = mouseWorldPos - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    void GameOver()
    {
        isGameOver = true;
    }

    private void GameIsPaused(bool state)
    {
        isPaused = state;
    }
}
