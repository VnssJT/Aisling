using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class DialogueSentence
{
    
    [TextArea(1, 1)]
    public string name;
    public Sprite characterIcon;
    
    [TextArea(3, 10)]
    public string sentence;

    public DialogueSentence(string name, string sentence)
    {
        this.name = name;
        this.sentence = sentence;
    }
}


[System.Serializable]
public class Dialogue
{
    public DialogueSentence[] sentences;

    public Dialogue(DialogueSentence[] sentences)
    {
        this.sentences = sentences;
    }
}   

 



