using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageable : Damageable
{
    public Enemy enemy;

    private Animator animator;

    private void Awake() 
    {
        animator = enemy.animator;
    }
    public override void ApplyDamageOrHill(float value, Transform damageDealer = null)
    {
        base.ApplyDamageOrHill(value, damageDealer);
        if (!death)
        {
            enemy.status = Enemy.Status.stunned;
            animator.SetBool("GetHit", true);
        }
    }

    public override void OnDeath(float deathTime = 1)
    {
        base.OnDeath(1);
        animator.SetBool("Death", true);
    }
}
