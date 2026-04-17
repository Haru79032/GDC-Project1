using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIHoverHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image targetImage;
    private const float hoverAlphaValue = 0.1f;
    private const float baseAlphaValue = 0.0f;

    private void Awake()
    {
        targetImage = GetComponent<Image>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (targetImage != null)
        {
            Color hoverColor = targetImage.color;
            hoverColor.a = hoverAlphaValue;
            targetImage.color = hoverColor;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (targetImage != null)
        {
            Color baseColor = targetImage.color;
            baseColor.a = baseAlphaValue;
            targetImage.color = baseColor;
        }
    }
}
