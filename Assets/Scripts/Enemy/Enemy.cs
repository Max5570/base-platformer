using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public Status status = Status.empty;

    public enum Status
    {
        empty,
        stunned,
        invulnerable
    }

}
