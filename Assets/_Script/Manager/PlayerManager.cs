using System.Collections;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private const int maxHP = 3;
    [SerializeField] private Collider2D myCollider;
    [SerializeField] private float invincibleTime;
    [SerializeField] private float flashCount;
    private int _currentHP;
    private bool isInvincible = false;
    private SpriteRenderer playerSpriteRenderer;

    void Awake()
    {
        _currentHP = maxHP;
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void DamageTaken()
    {
        _currentHP--;
        EventBroker.onTakingDamage?.Invoke(_currentHP);
        if (_currentHP <= 0)
        {
            EventBroker.onGameOver?.Invoke();   
        }
        else
        {
            StartCoroutine(InvincibleMode());
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fragment") ||
            collision.gameObject.CompareTag("Bug") ||
            collision.gameObject.CompareTag("Error") ||
            collision.gameObject.CompareTag("Bomb"))
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
        for (int i = 0; i < flashCount; i++)
        {
            if (playerSpriteRenderer != null)
            {
                playerSpriteRenderer.enabled = false;
                yield return new WaitForSeconds(invincibleTime/(2*flashCount));
                playerSpriteRenderer.enabled = true;
                yield return new WaitForSeconds(invincibleTime/(2*flashCount));
            }
        }
        //yield return new WaitForSeconds(invincibleTime);
        isInvincible = false;
    }
}
