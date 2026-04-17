using UnityEngine;
using UnityEngine.UI;
public class UIBatteryDisplay : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public UIBatteryData healthData;
    private Image healthImage;

    private void Awake()
    {
        healthImage = GetComponent<Image>();
    }

    private void Update()
    {
        if (healthImage != null && healthData != null)
        {
            switch (healthData.Health)
            {
                case 3:
                    healthImage.sprite = healthData.healthHigh;
                    break;
                case 2:
                    healthImage.sprite = healthData.healthModerate;
                    break;
                case 1:
                    healthImage.sprite = healthData.healthLow;
                    break;
            }
        }
    }
}
