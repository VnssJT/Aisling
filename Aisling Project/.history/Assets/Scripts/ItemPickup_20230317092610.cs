using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : InteractiveObject
{
    public override void Interact()
    {
        base.Interact();
        Debug.Log("picking item"); 
    }
}
