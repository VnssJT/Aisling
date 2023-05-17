using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerMaze : InteractiveObject
{
    public delegate void OnTriggered();
    public static OnTriggered onDialogueTriggered;

    public bool isTriggeredImediatly = false;


    override public void Interact()
    {
        base.Interact();
        Debug.Log("dialogue triggered");
        TriggerDialogue();
    }

    void TriggerDialogue()
    {
        onDialogueTriggered?.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isTriggeredImediatly && other.gameObject.tag == "Player")
        {
            TriggerDialogue();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Destroy(gameObject);
    }
}
