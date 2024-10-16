using UnityEngine;
using System.Collections;
using System.Collections.Generic; 
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    public float speed2 = 10f;
    public float originalSpeed;
    public Coroutine slowCoroutine;
    public float startHealth = 100;
    public float health;
    public int worth = 50;
    private bool isDead = false;

    [Header("Unity stuff")]
    public List<Image> healthBars; 

    void Start()
    {
        originalSpeed = speed;
        health = startHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

       
        foreach (Image healthBar in healthBars)
        {
            healthBar.fillAmount = health / startHealth;
        }

        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    public void StopSlowing()
    {
        if (slowCoroutine != null)
        {
            StopCoroutine(slowCoroutine);
            slowCoroutine = null;
        }
        ResetSpeed();
    }

    public void ResetSpeed()
    {
        speed = speed2;
        Debug.Log($"Speed reset to original: {speed}");
    }

    IEnumerator SlowEffect(float slowPct)
    {
        speed = originalSpeed * (1f - slowPct);
        yield return new WaitForSeconds(1f);
    }

    public void Slow(float slowPct)
    {
        if (slowCoroutine != null)
        {
            StopCoroutine(slowCoroutine);
        }
        slowCoroutine = StartCoroutine(SlowEffect(slowPct));
    }

    public void Slownew(float pct)
    {
        originalSpeed = speed * (1.5f - pct);
    }

    void Die()
    {
        isDead = true;
        PlayerState.money += worth;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
