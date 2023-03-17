using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class DialogueTriggerObject : InteractiveObject
{
    override public void triggered(){
        Debug.Log("dialogue triggered")
    }
}
