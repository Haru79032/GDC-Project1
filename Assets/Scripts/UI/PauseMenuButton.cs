public class PauseMenuButton :RegularButton
{
    protected override void TriggerSFX()
    {
        AudioManager.Instance.PlaySFX(SFXType.PAUSE_MENU_BUTTON_HOVERING);
    }
}