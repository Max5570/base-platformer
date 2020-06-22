using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    public float damage;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform == GameManager.instance.player.transform)
        {
            GameManager.instance.ChangePlayerHealth(damage, transform);
        }
    }
}
