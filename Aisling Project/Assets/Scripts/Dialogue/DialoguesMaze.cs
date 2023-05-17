using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguesMaze : MonoBehaviour
{
    Dialogue[] dialogues =
    {
        new Dialogue(
            new DialogueSentence[1] {new DialogueSentence(
                "Aisling", 
                "I'll be your best friend, Rito")}
        ),
        new Dialogue(
            new DialogueSentence[1] {new DialogueSentence(
                "Aisling",
                "Don't listen to them, Rito. I'm here with you")}
        ),
        new Dialogue(
            new DialogueSentence[1] {new DialogueSentence(
                "Aisling",
                "Let's play at the swings together")}
        ),
        new Dialogue(
            new DialogueSentence[1] {new DialogueSentence(
                "Ai5l1ng",
                "You got new fiends, Rito?")}
        ),
        new Dialogue(
            new DialogueSentence[1] {new DialogueSentence(
                "4?5l1?$#6·44gE!",
                "Hey, Rito. It's been a while.")}
        ),
        new Dialogue(
            new DialogueSentence[1] {new DialogueSentence(
                "???",
                "...Rito?")}
        ),
        new Dialogue(
            new DialogueSentence[1] {new DialogueSentence(
                "???",
                "...")}
        ),
        new Dialogue(
            new DialogueSentence[1] {new DialogueSentence(
                "???",
                "...")}
        ),
    };


    int currentIndex = 0;
    private DialogueManager dialogueManager;

    private void Start()
    {
        dialogueManager = GetComponent<DialogueManager>();

        DialogueTriggerMaze.onDialogueTriggered += StartDialogue;
    }

    private void OnDisable()
    {
        DialogueTriggerMaze.onDialogueTriggered -= StartDialogue;
    }

    private void StartDialogue()
    {
        dialogueManager.StartDialogue(dialogues[currentIndex]);
        currentIndex++;
    }
}
