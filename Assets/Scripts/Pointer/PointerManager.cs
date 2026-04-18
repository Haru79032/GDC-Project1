using UnityEngine;
using UnityEngine.InputSystem;
public class PointerManager : MonoBehaviour
{
    [SerializeField] private FakePointer pointer;
    [SerializeField] private PointerLibrary normalPointerLibrary;
    [SerializeField] private PointerLibrary largePointerLibrary;


    private void Awake()
    {
        if (normalPointerLibrary != null)
        {
            normalPointerLibrary.Initialize();
        }
        if (largePointerLibrary != null)
        {
            largePointerLibrary.Initialize();
        }
        DontDestroyOnLoad(gameObject);
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            UpdatePointer();
        }
    }

    private void Update()
    {
        UpdatePointer();
    }
    private void UpdatePointer()
    {
        Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
        bool isInside = mouseScreenPos.x >= 0 && mouseScreenPos.x <= Screen.width &&
                        mouseScreenPos.y >= 0 && mouseScreenPos.y <= Screen.height;
        Cursor.visible = !isInside;

    }
    private void OnEnable()
    {
        EventBroker.onPointerTriggerLoad += OnPointerIsLoading;
    }

    private void OnDisable()
    {
        EventBroker.onPointerTriggerLoad -= OnPointerIsLoading;
    }

    private void OnPointerIsLoading(bool isLoading)
    {
        if (pointer == null)
        {
            return;
        }

        if (isLoading)
        {
            pointer.GetComponent<SpriteRenderer>().sprite = normalPointerLibrary.GetPointer(PointerType.WAITING_POINTER);
        }
        else
        {
            pointer.GetComponent<SpriteRenderer>().sprite = normalPointerLibrary.GetPointer(PointerType.NORMAL_POINTER);
        }
    }
}