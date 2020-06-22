using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum Status
    {
        empty,
        stunned,
        invulnerable
    }

    public Status status;
    public PlayerMovement movement;
    public PlayerDamageable damageable;
}
