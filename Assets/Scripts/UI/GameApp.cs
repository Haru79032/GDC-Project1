using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameApp : AppButton
{
    [SerializeField] private Canvas gameExecCanvas;
    [SerializeField] private UIZoomContainer zoomContainer;
    private const string gameSceneName = "Game";

    protected override void OnMouseDoubleClick()
    {
        if (gameExecCanvas != null)
        {
            gameExecCanvas.gameObject.SetActive(true);
        }
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlaySFX(SFXType.APP_OPENING);
        }
        if (zoomContainer != null)
        {
            StartCoroutine(CallZoomInScreen());
        }
    }

    IEnumerator CallZoomInScreen()
    {
        EventBroker.onPointerTriggerLoad?.Invoke(true);
        yield return new WaitForSeconds(3.0f);
        yield return StartCoroutine(zoomContainer.ZoomInScreen());
        SceneManager.LoadScene(SceneContextHandler.Instance.GetIndexOfScene(gameSceneName));
        EventBroker.onPointerTriggerLoad?.Invoke(false);
        AudioManager.Instance.PlayPrimaryMusic(MusicType.DIGESTIVE_BISCUIT_GAME);
    }

}