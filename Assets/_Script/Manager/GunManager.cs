using UnityEngine;
using UnityEngine.InputSystem;

public class GunManager : MonoBehaviour
{
    [SerializeField] private Transform firePosition;    
    [SerializeField] private LineRenderer projectile;
    [SerializeField] private GameObject aimingLazer;
    [SerializeField] private ObjectPool pool;   
    [SerializeField] private float lazerTime;
    [SerializeField] private float defaultBulletSpeed = 5f; 
    private float bulletSpeed;
    private Camera mainCamera;
    private LineRenderer lazer;
    private bool isPaused = false;
    private bool isGameOver = false;

    void OnEnable()
    {
        EventBroker.onBulletHitSomething += ReturnBullet;
        EventBroker.onDifficultyEnhanced += EnhancingDifficulty;
        EventBroker.onGameOver += GameOver;
        EventBroker.onGamePaused += GameIsPaused;
    }

    void OnDisable()
    {
        EventBroker.onBulletHitSomething -= ReturnBullet;
        EventBroker.onDifficultyEnhanced -= EnhancingDifficulty;
        EventBroker.onGameOver -= GameOver;
        EventBroker.onGamePaused -= GameIsPaused;
    }

    void Awake()
    {
        bulletSpeed = defaultBulletSpeed;
    }

    void Start()
    {
        lazer = aimingLazer.GetComponent<LineRenderer>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (isPaused || isGameOver) return;

        UpdateAiming();

        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Shoot();
        }
    }

    void UpdateAiming()
    {
        Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(new Vector3(mouseScreenPos.x, mouseScreenPos.y, Camera.main.nearClipPlane));
        mouseWorldPos.z = 0f;

        Vector2 origin = firePosition.position; 
        Vector2 centerPos = transform.parent.position;
        Vector2 direction = ((Vector2)mouseWorldPos - centerPos).normalized;

        RaycastHit2D hitInfo = Physics2D.Raycast(origin, direction);

        lazer.SetPosition(0, origin);

        if (hitInfo)
        {
            lazer.SetPosition(1, hitInfo.point);
        }
        else
        {
            lazer.SetPosition(1, origin + direction * 100f);
        }
    }

    void Shoot()
    {
        Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(new Vector3(mouseScreenPos.x, mouseScreenPos.y, Camera.main.nearClipPlane));
        mouseWorldPos.z = 0f;

        Vector2 centerPos = transform.parent.position;
        Vector2 direction = ((Vector2)mouseWorldPos - centerPos).normalized;

        GameObject obj = pool.GetObject();
        obj.GetComponent<Transform>().position = firePosition.position; 
        obj.GetComponent<Rigidbody2D>().linearVelocity = direction * bulletSpeed;
        EventBroker.onBulletShot?.Invoke();
    }

    void ReturnBullet(Collider2D bullet)
    {
        pool.ReturnObject(bullet.gameObject);
    }

    void EnhancingDifficulty()
    {
        bulletSpeed += 0.25f;
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
