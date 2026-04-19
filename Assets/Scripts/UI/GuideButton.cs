using UnityEngine;
using UnityEngine.EventSystems;
public class GuideButton : RegularButton, IPointerClickHandler, IPointerExitHandler
{
    [SerializeField] private Canvas guideCanvas;
    protected override void OnPointerEntering()
    {
        EventBroker.onPointerCanClick?.Invoke(true);
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlaySFX(SFXType.GUIDE_NOTES_HOVERING);
        }
    }

    public void OnPointerClick(PointerEventData pointerEvent)
    {
        if (guideCanvas == null)
        {
            return;
        }
        bool activeState = !guideCanvas.gameObject.activeInHierarchy;
        guideCanvas.gameObject.SetActive(activeState);
        EventBroker.onPointerOpenGuide?.Invoke(activeState);
    }

    public void OnPointerExit(PointerEventData pointerEvent)
    {
        EventBroker.onPointerCanClick?.Invoke(false);
    }
}