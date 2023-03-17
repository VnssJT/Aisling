using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : InteractiveObject
{
    public override void triggered()
    {
        Debug.Log("picking item");
    }
}
