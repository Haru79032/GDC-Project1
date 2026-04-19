using UnityEngine;
using UnityEngine.EventSystems;
public abstract class RegularButton : MonoBehaviour, IPointerEnterHandler
{

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnPointerEntering();
    }

    protected abstract void OnPointerEntering();
}