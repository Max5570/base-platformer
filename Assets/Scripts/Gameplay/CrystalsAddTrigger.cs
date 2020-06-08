using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalsAddTrigger : MonoBehaviour
{
    public float addCristals = 1;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.GetComponent<Player>() != null)
        {
            Destroy(gameObject);
            GameManager.instance.crystalsCount.text = (int.Parse(GameManager.instance.crystalsCount.text) + addCristals).ToString();
            addCristals = 0;
        }
    }
}
