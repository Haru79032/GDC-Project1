using UnityEngine;
using UnityEngine.SceneManagement;

public class AppPanel : MonoBehaviour
{
    [SerializeField] private Canvas settingsCanvas;
    [SerializeField] private UIZoomContainer zoomContainer;
    private const string gameSceneName = "Game";

    public void StartGame()
    {
        /*if (zoomContainer != null){
            zoomContainer.isZooming = true;
        }*/

        SceneManager.LoadScene(SceneContextHandler.Instance.GetIndexOfScene(gameSceneName));
    }

    public void OpenNote()
    {
        
    }
    public void OpenSettings()
    {
        if (settingsCanvas != null)
        {
            settingsCanvas.gameObject.SetActive(true);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}