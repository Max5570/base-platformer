using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    public float damage;
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.transform.GetComponent<Damageable>() != null)
        {
            other.transform.GetComponent<Damageable>().ApplyDamageOrHill(damage);
        }
    }
}
