public class PauseMenuButton : RegularButton
{
    protected override void OnPointerEntering()
    {
        AudioManager.Instance.PlaySFX(SFXType.PAUSE_MENU_BUTTON_HOVERING);
    }
}