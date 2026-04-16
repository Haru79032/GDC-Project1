using System.Collections;
using UnityEngine;

public class Shockwave : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float shockwaveRadius = 5f;
    [SerializeField] private float duration = 0.5f; 
    [SerializeField] private Collider2D mycollider;
    void Start()
    {
        StartCoroutine(ScaleOverTime(duration, shockwaveRadius));
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x >= shockwaveRadius)
        {
            EventBroker.onShockwaveHitSomething?.Invoke(mycollider);
        }
    }
    private IEnumerator ScaleOverTime(float duration, float maxScale)
    {
        float currentTime = 0f;
        Vector3 initialScale = transform.localScale;
        Vector3 targetScale = new Vector3(maxScale, maxScale, maxScale);

        while (currentTime < duration)
        {
            transform.localScale = Vector3.Lerp(initialScale, targetScale, currentTime / duration);
            currentTime += Time.deltaTime;
            yield return null;
        }
        transform.localScale = targetScale;
    }
}
