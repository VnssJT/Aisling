using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerObject : InteractiveObject
{

    public Dialogue dialogue;
    private bool readyToTalk = false;
    [HideInInspector] public bool dialogueInCourse = false;
    public bool isTriggeredImediatly = false;
    public bool showOnce = true;
    DialogueManager dialogueManager;


    override public void Interact(){
        base.Interact();
        Debug.Log("dialogue triggered");
    }

    void TriggerDiaologue(){
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        dialogueInCourse = true;
        if(showOnce){
            Destroy(gameObject);                
        }  
    }
}
