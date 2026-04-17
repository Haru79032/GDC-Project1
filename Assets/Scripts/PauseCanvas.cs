using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseCanvas : MonoBehaviour
{
    [SerializeField] private Canvas pauseCanvas;
    [SerializeField] private Canvas settingsCanvas;

    private void OnEnable()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayInterruptMusic(MusicType.UP_IN_MY_JAM_PAUSE_MENU);
        }
    }

    public void ContinueGame()
    {
        if (pauseCanvas != null)
        {
            pauseCanvas.gameObject.SetActive(false);
        }
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.ResumePrimaryMusic();
        }
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
    }

    public void OpenSettings()
    {
        if (settingsCanvas != null)
        {
            settingsCanvas.gameObject.SetActive(true);
        }
    }

    public void OpenInfo()
    {
        
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
    }
}