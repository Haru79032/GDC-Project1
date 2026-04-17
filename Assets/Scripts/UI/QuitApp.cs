using UnityEngine;

public class QuitApp : AppButton
{
    protected override void OnMouseDoubleClick()
    {
        Application.Quit();
    }
}