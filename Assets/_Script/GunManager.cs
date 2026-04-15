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
    [SerializeField] private float lazerTime;   
    private Camera mainCamera;
    private LineRenderer lazer;
    private Vector2 origin;
    void Start()
    {
        lazer = aimingLazer.GetComponent<LineRenderer>();
        mainCamera = Camera.main;
        origin = firePosition.position;
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

        Vector2 centerPos = transform.parent.position;
        Vector2 origin = firePosition.position;
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
        Vector2 origin = firePosition.position;
        Vector2 direction = ((Vector2)mouseWorldPos - centerPos).normalized;

        RaycastHit2D hitInfo = Physics2D.Raycast(origin, direction);

        projectile.SetPosition(0, origin);

        if (hitInfo)
        {
            projectile.SetPosition(1, hitInfo.point);
            
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                EventBroker.somethingIsShot?.Invoke(hitInfo.collider);
            }
        }
        else
        {
            projectile.SetPosition(1, origin + direction * 100f);
        }
        
        StartCoroutine(ShootLazerEffect());
    }
    IEnumerator ShootLazerEffect()
    {
        projectile.enabled = true;
        yield return new WaitForSeconds(lazerTime);
        projectile.enabled = false;
    }
}
