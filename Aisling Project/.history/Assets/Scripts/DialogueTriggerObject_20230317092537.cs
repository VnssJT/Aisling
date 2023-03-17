using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerObject : InteractiveObject
{
    override public void Interact(){
        Debug.Log("dialogue triggered");
    }
}
