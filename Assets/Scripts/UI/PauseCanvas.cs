using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseCanvas : MonoBehaviour
{
    [SerializeField] private Canvas pauseCanvas;
    [SerializeField] private Canvas settingsCanvas;
    [SerializeField] private Canvas guideCanvas;

    /*private void OnEnable()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayInterruptMusic(MusicType.UP_IN_MY_JAM_PAUSE_MENU);
        }
    }*/

    public void ContinueGame()
    {
        if (pauseCanvas != null)
        {
            pauseCanvas.gameObject.SetActive(false);
        }
        /*if (AudioManager.Instance != null)
        {
            AudioManager.Instance.ResumePrimaryMusic();
        }*/
        Time.timeScale = 1.0f;
        EventBroker.onGamePaused?.Invoke(false);
    }

    public void RestartGame()
    {
        if (pauseCanvas != null)
        {
            pauseCanvas.gameObject.SetActive(false);
        }
        if (SceneContextHandler.Instance != null)
        {
            SceneManager.LoadSceneAsync(SceneContextHandler.Instance.GetIndexOfScene("Game"));
        }
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayPrimaryMusic(MusicType.DIGESTIVE_BISCUIT_GAME);
        }
        Time.timeScale = 1.0f;
    }

    public void OpenSettings()
    {
        if (settingsCanvas != null)
        {
            settingsCanvas.gameObject.SetActive(true);
        }
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlaySFX(SFXType.APP_OPENING);
        }
    }

    public void OpenGuides()
    {
        if (guideCanvas != null)
        {
            guideCanvas.gameObject.SetActive(true);
        }
        EventBroker.onPointerOpenGuide?.Invoke(true);
    }

    public void ExitGame()
    {
        if (SceneContextHandler.Instance != null)
        {
            SceneManager.LoadSceneAsync(SceneContextHandler.Instance.GetIndexOfScene("MainMenu"));
        }
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayPrimaryMusic(MusicType.UNDERCLOCKED_MAIN_MENU);
        }
        Time.timeScale = 1.0f;
    }
}