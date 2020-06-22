using System;
using UnityEngine;

public class PlayerDamageable : Damageable
{
    public Animator animator;

    public override void ApplyDamageOrHill(float value, Transform damageDealer = null)
    {
        base.ApplyDamageOrHill(value, damageDealer);
        if (!death)
        {
            animator.SetTrigger("GetHit");
        }
    }
    public override void OnDeath(float deathTime){}

    public void Revive()
    {
        currentHealth = maxHealth;
        death = false;
    }
}