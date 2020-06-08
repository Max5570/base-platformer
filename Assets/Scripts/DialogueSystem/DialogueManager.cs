using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : Singleton<DialogueManager>
{
    public Animator animator;
    public Text nameText; 
    public Text dialogueText;
    public Image faceImage;
    [Space(10)]
    public Dialogue[] dialogue;

    private int sentenceIndex;
    private int currentDialogIndex;
    

    public void StartDialogue(int index)
    {
        //Set open animation
        animator.SetBool("IsOpen", true);
        //Start dialog from 0 sentence
        sentenceIndex = 0;
        currentDialogIndex = index;
        //Made player stand still during dialogue
        GameManager.instance.SetPlayerStatus(Player.Status.stunned);

        DisplayNextSentence();
    }
    ///<Summary>
    /// Display next sentense from dialogues array
    ///</Summary>
    public void DisplayNextSentence()
    {
        if (sentenceIndex == dialogue[currentDialogIndex].sentences.Length)
        {
            EndDialogue();
            return;
        }

        nameText.text = dialogue[currentDialogIndex].sentences[sentenceIndex].name;
        //Load talking face image by name
        Debug.Log(nameText.text);
        faceImage.sprite = Resources.Load<Sprite>(nameText.text);

        string sentence = dialogue[currentDialogIndex].sentences[sentenceIndex].sentence;
        //Display text whis animation
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

        sentenceIndex ++;
    }

    private IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";

        foreach (var letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(.03f);
        }
    }

    private void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        //Now player can move
        GameManager.instance.SetPlayerStatus(Player.Status.empty);
    }
}
