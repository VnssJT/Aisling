using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public TextMeshProUGUI EText;
    private bool readyToTalk = false;
    [HideInInspector] public bool dialogueInCourse = false;
    public bool isTriggeredImediatly = false;
    public bool showOnce = true;
    


    void Awake(){
        EText.enabled = false;
    }

    public void TriggerDialogue(){
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        dialogueInCourse = true;
        if(showOnce){
            EText.enabled = false;
            Destroy(gameObject);                
        }            
    }

    private void OnTriggerEnter(Collider other) {
        if(!dialogueInCourse && other.gameObject.tag == "Player"){
            if(isTriggeredImediatly)
            {
                TriggerDialogue();
            } else {
                EText.enabled = true;
                readyToTalk = true;                    
            }

        }
    }

    private void OnTriggerExit(Collider other) {
        if(!dialogueInCourse && other.gameObject.tag == "Player"){
            EText.enabled = false;
            readyToTalk = false;
        }
    }

    void Update(){
        if(!dialogueInCourse && !isTriggeredImediatly && readyToTalk && Input.GetKeyDown(KeyCode.E)){
            TriggerDialogue();
        }
    }
}
