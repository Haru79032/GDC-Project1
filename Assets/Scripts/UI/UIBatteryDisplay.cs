using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class UIBatteryDisplay : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private int flashCount;
    [SerializeField] private float flashTime;
    public UIBatteryData healthData;
    private Image healthImage;
    private int _currentHealthState = 3;
    private bool isPaused = false;
    private bool isGameOver = false;

    private void Awake()
    {
        healthImage = GetComponent<Image>();
    }

    private void OnEnable()
    {
        EventBroker.onTakingDamage += UpdateHealthState;
        EventBroker.onGameOver += GameOver;
        EventBroker.onGamePaused += GameIsPaused;
    }

    private void OnDisable()
    {
        EventBroker.onTakingDamage -= UpdateHealthState;
        EventBroker.onGameOver -= GameOver;
        EventBroker.onGamePaused -= GameIsPaused;
    }

    private void Update()
    {
        if (isPaused || isGameOver)
        {
            return;
        }
        if (healthImage != null && healthData != null)
        {
            switch (_currentHealthState)
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

    private void UpdateHealthState(int newState)
    {
        _currentHealthState = newState;
        StartCoroutine(FlashingEffect());
    }

    private void GameOver()
    {
        isGameOver = true;
    }

    private void GameIsPaused(bool state)
    {
        isPaused = state;
    }

    IEnumerator FlashingEffect()
    {
        for (int i = 0; i < flashCount; i++)
        {
            if (healthImage != null)
            {
                healthImage.enabled = false;
                yield return new WaitForSeconds(flashTime/(2*flashCount));
                healthImage.enabled = true;
                yield return new WaitForSeconds(flashTime/(2*flashCount));
            }
        }
    }
}
