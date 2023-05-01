using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
TODO:
- Change the input map so that once the dialogue is progress, 
  pressing z doesn't triggers it again
- Change the input system
*/

public class DialogueManager : MonoBehaviour
{

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public UnityEngine.UI.Image characterIcon;
    private Queue<DialogueSentence> sentences;
    public bool dialogueInCourse = false;
    public Animator animator;
    private DialogueSentence currentSentence;


    // EVENTS
    public delegate


    void Start()
    {
        sentences = new Queue<DialogueSentence>();
    }

    void Update(){
        /*
        if dialogue is in course
            if mouse cliked
                if the whole sentence is on screen
                    display next sentence
                else
                    stop the coroutine
                    diplay the whole sentence 
        */
        if(dialogueInCourse){
            if(Input.GetKeyDown(KeyCode.Z)){
                if(dialogueText.text == currentSentence.sentence){
                    DisplayNextSentence();
                } else {
                    StopAllCoroutines();
                    dialogueText.text = currentSentence.sentence;
                }
            }            
        }
    }

    public void StartDialogue(Dialogue dialogue){
        //Debug.Log("Sarting conversation with " + dialogue.name);

        //nameText.text = dialogue.name;
        dialogueInCourse = true;
        animator.SetBool("isOpen", true);
        sentences.Clear();

        foreach(DialogueSentence sentence in dialogue.sentences){
            sentences.Enqueue(sentence);

        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence(){
        if(sentences.Count == 0){
            EndDialogue();
            return;
        }

        /*DialogueSentence sentence = sentences.Dequeue();
        string sentenceContent = sentence.sentence;
        nameText.text = sentence.name;
        characterIcon.sprite = sentence.characterIcon;
*/
        currentSentence = sentences.Dequeue();
        string sentenceContent = currentSentence.sentence;
        nameText.text = currentSentence.name;
        characterIcon.sprite = currentSentence.characterIcon;


        Color tmp = characterIcon.color;
        tmp.a = currentSentence.characterIcon == null? 0f : 1f;
        characterIcon.color= tmp;


        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentenceContent));

    }

    IEnumerator TypeSentence(string sentence){
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue(){
        //Debug.Log("End of conversation");
        dialogueInCourse = false;
        animator.SetBool("isOpen", false);
        
    }

}


