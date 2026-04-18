using UnityEngine;
using UnityEngine.EventSystems;
public abstract class AppButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.clickCount == 2)
        {
            OnMouseDoubleClick();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlaySFX(SFXType.APP_HOVERING);
        }
    }

    protected abstract void OnMouseDoubleClick();
}