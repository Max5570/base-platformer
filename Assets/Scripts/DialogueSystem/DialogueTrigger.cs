using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public int dialogueIndex;
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.transform.GetComponent<Player>() != null)
        {
            DialogueManager.instance.StartDialogue(dialogueIndex);
        }
    }
}
