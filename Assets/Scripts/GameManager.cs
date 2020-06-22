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
    public bool loadLevel = true;

    private void Start()
    {
        StartLevel();
        if(loadLevel)
            SceneManager.LoadScene("1_1", LoadSceneMode.Additive);
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

    public void SetPlayerStatus(Player.Status status, float time = 0)
    {
        player.status = status;
        if (time != 0)
        {
            StopAllCoroutines();
            StartCoroutine(SetPlayerStatusAfterTime(status, time));
        }
    }

    private IEnumerator SetPlayerStatusAfterTime(Player.Status status, float time)
    {
        yield return new WaitForSeconds(time);
        player.status = status;
    }

    public void ChangePlayerHealth(float damage, Transform damageDealer = null)
    {
        if (player.status != Player.Status.invulnerable)
        {
            player.damageable.ApplyDamageOrHill(damage, damageDealer);
            if (!player.damageable.death)
            {
                player.status = Player.Status.invulnerable;
                //SetPlayerStatus(Player.Status.invulnerable);
                SetPlayerStatus(Player.Status.empty, 2);
            }else{
                RestartLevel();
            }
        }
    }
}
