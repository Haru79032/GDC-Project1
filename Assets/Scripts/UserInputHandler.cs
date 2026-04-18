using UnityEngine;

public class UserInputHandler : MonoBehaviour
{
    [SerializeField] private Canvas pauseCanvas;
    private InputSystem_Actions inputActions;
    private bool isPaused = false;
    private bool isGameOver = false;
    private void Awake()
    {
        inputActions = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        inputActions.UI.Enable();
        EventBroker.onGameOver += GameOver;
        EventBroker.onGamePaused += GameIsPaused;
    }

    private void OnDisable()
    {
        inputActions.UI.Disable();
        EventBroker.onGameOver -= GameOver;
        EventBroker.onGamePaused -= GameIsPaused;
    }

    private void Update()
    {
        if (isPaused || isGameOver)
        {
            return;
        }

        if (inputActions.UI.PauseGame.WasPressedThisFrame())
        {
            if (pauseCanvas != null)
            {
                pauseCanvas.gameObject.SetActive(true);
            }
            Time.timeScale = 0.0f;
            EventBroker.onGamePaused?.Invoke(true);
        }

    }

    private void GameOver()
    {
        isGameOver = true;
    }

    private void GameIsPaused(bool state)
    {
        isPaused = state;
    }
}