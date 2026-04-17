using UnityEngine;
[CreateAssetMenu]
public class UIBatteryData : ScriptableObject
{
    public Sprite healthHigh;
    public Sprite healthModerate;
    public Sprite healthLow;
    private int health = MAX_HEALTH;
    private const int MAX_HEALTH = 3;
    public int Health
    {
        get => health;
        set => health = Mathf.Clamp(value, 0, MAX_HEALTH);
    }
}
