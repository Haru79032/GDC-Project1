using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float maxHP;
    [SerializeField] private Collider2D myCollider;
    [SerializeField] private float invincibleTime;
    [SerializeField] private TextMeshProUGUI HPtext;
    private float _currentHP;
    private bool isInvincible = false;
    void Awake()
    {
        _currentHP = maxHP;
        HPtext.text = $"HP: {_currentHP}";
    }

    void DamageTaken()
    {
        _currentHP--;
        HPtext.text = $"HP: {_currentHP}";
        if (_currentHP <= 0)
        {
            Debug.Log("Game Over");
            EventBroker.onGameOver?.Invoke();   
        }
        else
        {
            Debug.Log("PLayer took damage");
            StartCoroutine(InvincibleMode());
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fragment") ||
            collision.gameObject.CompareTag("Enemy") ||
            collision.gameObject.CompareTag("Enemy2") ||
            collision.gameObject.CompareTag("Enemy3"))
        {
            if (!isInvincible)
            {
                EventBroker.onEnemyHitPlayer?.Invoke(collision);
                DamageTaken();
            }
        }
    }

    IEnumerator InvincibleMode()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibleTime);
        isInvincible = false;
    }
}
