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
}


[System.Serializable]
public class Dialogue
{
    public DialogueSentence[] sentences;
}   

 



