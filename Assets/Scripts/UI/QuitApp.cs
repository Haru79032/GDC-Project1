using System.Collections;
using UnityEngine;

public class QuitApp : AppButton
{
    protected override void OnMouseDoubleClick()
    {
        /*if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlaySFX(SFXType.GAME_EXIT);
        }*/
        Application.Quit();
    }
}