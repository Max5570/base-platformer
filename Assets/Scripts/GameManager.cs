using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public Player player;
    public Text crystalsCount;
    public Fade fade;
    public Transform playerStartPosition;
    private void Start()
    {
        StartLevel();
    }

    public void RestartLevel()
    {
        StartLevel();
    }

    private void StartLevel()
    {
        SetPlayerStatus(Player.Status.stunned);
        player.transform.position = playerStartPosition.position;
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        if (!player.movement.controller.m_FacingRight)
        {
            player.movement.controller.Flip();
        }
        fade.gameObject.SetActive(true);
        fade.FadeOut();
    }
    
    private void EndLevel()
    {
        fade.gameObject.SetActive(true);
        fade.FadeIn();
    }

    public void SetPlayerStatus(Player.Status status)
    {
        player.status = status;
    }
}
