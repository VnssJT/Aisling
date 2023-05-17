using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerObject : InteractiveObject
{

    public Dialogue dialogue;
    public DialogueManager dialogueManager;


    override public void Interact(){
        base.Interact();
        Debug.Log("dialogue triggered");
        TriggerDialogue();
    }

    void TriggerDialogue(){
        dialogueManager.StartDialogue(dialogue);
    }
}
