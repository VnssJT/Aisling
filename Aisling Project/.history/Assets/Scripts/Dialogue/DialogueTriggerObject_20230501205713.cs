using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerObject : InteractiveObject
{

    public Dialogue dialogue;
    [HideInInspector] public bool dialogueInCourse = false;
    public DialogueManager dialogueManager;


    override public void Interact(){
        base.Interact();
        Debug.Log("dialogue triggered");
        TriggerDiaologue();
    }

    void TriggerDiaologue(){
        dialogueManager
        dialogueInCourse = true;
    }
}
