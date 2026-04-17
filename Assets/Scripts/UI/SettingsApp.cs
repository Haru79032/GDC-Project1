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
    }
}