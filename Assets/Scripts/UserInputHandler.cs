using UnityEngine;

public class UserInputHandler : MonoBehaviour
{
    [SerializeField] private Canvas pauseCanvas;
    private InputSystem_Actions inputActions;
    private void Awake()
    {
        inputActions = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        inputActions.UI.Enable();
    }

    private void OnDisable()
    {
        inputActions.UI.Disable();
    }

    private void Update()
    {
        if (inputActions.UI.PauseGame.WasPressedThisFrame())
        {
            if (pauseCanvas != null)
            {
                pauseCanvas.gameObject.SetActive(true);
            }
        }
    }
}