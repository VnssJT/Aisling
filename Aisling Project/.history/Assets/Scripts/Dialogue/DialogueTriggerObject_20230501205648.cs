using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerObject : InteractiveObject
{

    public Dialogue dialogue;
    [HideInInspector] public bool dialogueInCourse = false;
    public bool showOnce = true;
    public DialogueManager dialogueManager;


    override public void Interact(){
        base.Interact();
        Debug.Log("dialogue triggered");
        TriggerDiaologue();
    }

    void TriggerDiaologue(){
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        dialogueInCourse = true;
    }
}