using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : InteractiveObject
{
    public Item item;
    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    private void PickUp(){
        Debug.Log("picking " + item.); 

        // Add to inventory
        Destroy(gameObject);
    }
}
