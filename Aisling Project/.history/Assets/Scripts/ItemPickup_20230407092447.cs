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
        Debug.Log("picking " + item.name); 

        // Add to inventory
        if(Inventory.instance.Add(item)){
            Destroy(gameObject);
        }

        // Add to memory
        if(item is MemoryFragment){
            // Get the memoryID
        }
    }
}
