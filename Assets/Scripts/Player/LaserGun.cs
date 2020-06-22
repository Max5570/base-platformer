using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : WeaponBase
{
    public GameObject VFX;
    public LineRenderer laser;
    public LineRenderer lightning;
    public ParticleSystem hitFX;
    public LayerMask layerMask;
    public Transform firePoint;

    private bool attacking;
    private Transform currentTarget;
    private Damageable damageableTarget;

    private void Start() 
    {
        Vector3 offset = new Vector3(.35f, .35f, 0);
        laser.SetPosition(0, transform.position);
        lightning.SetPosition(0, transform.position + offset);
    }

    public override void Attack()
    {
        attacking = true;
        VFX.SetActive(true);
    }

    public void EndAttack()
    {
        attacking = false;
        VFX.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Attack();
        }

        Transform target = OnAttack();
        if (target)
        {
            if (target != currentTarget)
            {
                FreeTarget();
                currentTarget = target;
                if (currentTarget.GetComponent<Damageable>() != null)
                {
                    damageableTarget = currentTarget.GetComponent<Damageable>();
                }
            }
            if (damageableTarget)
            {
                damageableTarget.ApplyDamageOrHill(.2f);
            }
        } else
        {
            FreeTarget();
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            EndAttack();
            FreeTarget();
        }
    }

    private void FreeTarget()
    {
        try
        {
            Enemy enemy = currentTarget.GetComponent<Enemy>();
            enemy.status = Enemy.Status.empty;
            enemy.animator.SetBool("GetHit", false);
        } catch{}
    }

    private Transform OnAttack()
    {
        if(attacking)
        {
            float direction = transform.parent.localScale.x;
            Vector3 laserOffset = transform.right * .15f * direction;
            Vector3 lightningOffset = new Vector3(0.1f, .2f, 0) * direction;
            laser.SetPosition(0, firePoint.position - laserOffset);
            lightning.SetPosition(0,  firePoint.position + lightningOffset);

            RaycastHit2D hit = Physics2D.Linecast(transform.position, transform.position + transform.right * 1.5f * direction, layerMask);
            if (hit)
            {
                Vector2 movePoint = hit.point + Vector2.up * .06f;
                laser.SetPosition(1, new Vector2(movePoint.x + .2f * direction, firePoint.position.y));
                lightning.SetPosition(1, new Vector2(movePoint.x, firePoint.position.y + .2f * direction));
                hitFX.transform.position = movePoint;
                return hit.transform;
            }
            else
            {
                Vector2 movePoint = transform.position + transform.right * 1.5f * direction;

                laser.SetPosition(1, new Vector2(movePoint.x  + .2f * direction, firePoint.position.y));
                lightning.SetPosition(1, new Vector2(movePoint.x, firePoint.position.y + .26f * direction));
                hitFX.transform.position = new Vector2(movePoint.x, firePoint.position.y);
            }
        }
        return null;
    }
}
