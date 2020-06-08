using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Player player;
    public CharacterController controller;
    public Animator animator;
    [Space(10)]
    [Header("Properties")]
    public float moveSpeed = 40;

    private float horizontalMove;
    private bool jump;

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
    }

    private void FixedUpdate() 
    {
        if (player.status == Player.Status.stunned)
        {
            animator.SetBool("Move", false);
            return;
        }
        
        float speed = horizontalMove * Time.deltaTime * moveSpeed;
        controller.Move(speed, false, jump);
        if (speed != 0)
        {
            animator.SetBool("Move", true);
        }
        else
        {
            animator.SetBool("Move", false);
        }
        if (jump)
        {
            animator.SetTrigger("Jump");
        }
        jump = false;
    }
}
