using UnityEngine;
using UnityEngine.SceneManagement;
public class PromptPanel : MonoBehaviour
{
    public void RetryGame()
    {
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

    public void ReturnToMainMenu()
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