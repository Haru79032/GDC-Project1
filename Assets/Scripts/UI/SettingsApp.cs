using UnityEngine;

public class SettingsApp : AppButton
{
    [SerializeField] private Canvas settingsCanvas;

    protected override void OnMouseDoubleClick()
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
}