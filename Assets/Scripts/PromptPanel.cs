using UnityEngine;
using UnityEngine.SceneManagement;
public class PromptPanel : MonoBehaviour
{
    public void RetryGame()
    {
        SceneManager.LoadSceneAsync(SceneContextHandler.Instance.GetIndexOfScene("Game"));
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadSceneAsync(SceneContextHandler.Instance.GetIndexOfScene("MainMenu"));
    }
}