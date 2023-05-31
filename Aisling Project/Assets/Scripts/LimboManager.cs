using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DialogueManager;

public class LimboManager : MonoBehaviour
{
    float timeSinceStarted = 0;
    [SerializeField] float[] timetoTriggerDialogue;
    [SerializeField] DialogueTriggerObject[] dialogues;
    [SerializeField] DialogueManager dialogueManager;
    List<bool> dialogueStarted = new List<bool>();
    bool countTime = true;
    int currentDialogueIndex = 0;
    [SerializeField] GameObject DecisionTriggers;
    float triggersDistanceFromPlayer = 5f;

    // Start is called before the first frame update
    void Start()
    {
        foreach (DialogueTriggerObject dialogue in dialogues)
        {
            dialogue.dialogueManager = dialogueManager;
            dialogueStarted.Add(false);
        }
        
        DialogueManager.onDialogueEnded += DialogueManager_onDialogueEnded;

        // Add RED memory to inventory
        MemoryManager.instance.AddFragment(MemoryManager.MemoryIndex.RED, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (countTime)
        {
            timeSinceStarted += Time.deltaTime;
        }

        if(timeSinceStarted > timetoTriggerDialogue[currentDialogueIndex])
        {
            //Debug.Log("LIMBO: Dialogue triggered");
            if (!dialogueStarted[currentDialogueIndex])
            {
                dialogueManager.StartDialogue(dialogues[currentDialogueIndex].dialogue);
                dialogueStarted[currentDialogueIndex] = true;
                countTime = false;
            }
            
        }
    }

    void DialogueManager_onDialogueEnded()
    {
        // It's the last dialogue
        if(currentDialogueIndex == dialogues.Length - 1)
        {
            //Debug.Log("LIMBO MANAGER: Activating decision triggers");
            DecisionTriggers.SetActive(true);
            Vector3 playerPos = PlayerController.instance.transform.position;
            DecisionTriggers.transform.position = new Vector3(playerPos.x, 0f, playerPos.z + triggersDistanceFromPlayer);
            return;
        }

        currentDialogueIndex++;
        timeSinceStarted = 0f;
        countTime = true;
    }
}
