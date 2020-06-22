using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public bool death = false;
    public float maxHealth;
    public float currentHealth;

    public Transform healthBar;
    public bool getReward = false;
    public int reward = 10;

    public virtual void ApplyDamageOrHill(float value, Transform damageDealer = null)
    {
        currentHealth -= value;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            if (!death)
            {
                death = true;
                OnDeath();
            }
        }
        if (healthBar != null)
        {
            Vector2 x = new Vector2(currentHealth/maxHealth * 2, healthBar.localScale.y);
            healthBar.localScale = x;
        }
    }

    private void FixedUpdate() 
    {
        if (transform.position.y < -20 && !death)
        {
            OnDeath();
        }
    }


    public virtual void OnDeath(float deathTime = .1f)
    {
        Destroy(gameObject, deathTime);
        
        if (getReward)
        {
            GameManager.instance.crystalsCount.text = (int.Parse(GameManager.instance.crystalsCount.text) + reward).ToString();
        }
    }
}