using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : InteractiveObject
{
    public override void Interact()
    {
        base.Interact();
    }

    private void PickUp(){
        
        Debug.Log("picking item"); 
        
    }
}
