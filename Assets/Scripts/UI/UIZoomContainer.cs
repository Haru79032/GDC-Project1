using System;
using System.Collections;
using UnityEngine;

public class UIZoomContainer : MonoBehaviour
{
    [SerializeField] private float maxZoom = 10.0f;
    [SerializeField] private float maxZoomDuration = 3.0f;
    private RectTransform zoomContainer;
    private Vector3 finalScale;

    private void Awake()
    {
        zoomContainer = GetComponent<RectTransform>();
        finalScale = zoomContainer.localScale * maxZoom;
    }

    public IEnumerator ZoomInScreen()
    {
        float elapsedTime = 0.0f;
        AudioManager.Instance.PlaySFX(SFXType.UI_ZOOM_IN);
        while (elapsedTime < maxZoomDuration)
        {
            elapsedTime += Time.deltaTime;
            float tStep = elapsedTime / maxZoomDuration;
            float easedTStep = tStep * tStep;
            Vector3 oldScale = zoomContainer.localScale;
            zoomContainer.localScale = Vector3.Lerp(oldScale, finalScale, easedTStep);
            yield return null;
        }
    }
}
