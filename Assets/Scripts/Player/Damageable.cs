using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public bool restartOnDeath;
    public float maxHealth;
    public float currentHealth;

    public Transform healthBar;

    public void ApplyDamageOrHill(float value, Transform damageDealer = null)
    {
        currentHealth -= value;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            OnDeath();
        }
        if (healthBar != null)
        {
            Vector2 x = new Vector2(currentHealth/maxHealth * 2, healthBar.localScale.y);
            healthBar.localScale = x;
        }
    }

    private void FixedUpdate() 
    {
        if (transform.position.y < -20)
        {
            OnDeath();
        }
    }

    private void OnDeath()
    {
        if (restartOnDeath)
        {
            GameManager.instance.RestartLevel();
            return;
        }
        Destroy(gameObject, .4f);
        GameManager.instance.crystalsCount.text = (int.Parse(GameManager.instance.crystalsCount.text) + 10).ToString();
    }
}