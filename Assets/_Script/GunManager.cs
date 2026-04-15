using System.Collections;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunManager : MonoBehaviour
{
    [SerializeField] private Transform firePosition;    
    [SerializeField] private LineRenderer projectile;
    [SerializeField] private GameObject aimingLazer;
    [SerializeField] private ObjectPool pool;   
    [SerializeField] private float lazerTime;
    [SerializeField] private float bulletSpeed = 5f;
    private Camera mainCamera;
    private LineRenderer lazer;

    void OnEnable()
    {
        EventBroker.onBulletHitSomething += returnBullet;
    }

    void OnDisable()
    {
        EventBroker.onBulletHitSomething -= returnBullet;
    }

    void Start()
    {
        lazer = aimingLazer.GetComponent<LineRenderer>();
        mainCamera = Camera.main;
    }

    void Update()
    {
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
    }

    void returnBullet(Collider2D bullet)
    {
        pool.ReturnObject(bullet.gameObject);
    }
}
