using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    private Image image;
    private void Awake() {
        image = GetComponent<Image>();
    }

    public void FadeOut(float time = 1)
    {
        StartCoroutine(FadeOutSmoth(time));
    }

    private IEnumerator FadeOutSmoth(float time)
    {
        Color color = image.color;
        color.a = 1;
        for (float i = 0; i < 1; i += Time.deltaTime / time)
        {
            yield return null;
            color.a -= Time.deltaTime / time;
            image.color = color;
        }
        GameManager.instance.SetPlayerStatus(Player.Status.empty);
    }

    public void FadeIn(float time = 1)
    {
        StartCoroutine(FadeInSmoth(time));
    }

    private IEnumerator FadeInSmoth(float time)
    {
        Color color = image.color;
        color.a = 0;

        for (float i = 0; i < 1; i += Time.deltaTime / time)
        {
            yield return null;
            color.a += Time.deltaTime / time;
            image.color = color;
        }
        gameObject.SetActive(false);
    }
}
