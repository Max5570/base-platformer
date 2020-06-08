using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue/Instance")]
public class Dialogue : ScriptableObject
{
    public DialogueSentences[] sentences;
}
