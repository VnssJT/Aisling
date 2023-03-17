using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    Inventory Instance 
    public List<Item> items = new List<Item>();

    public void Add(Item item){
        items.Add(item);
    }

    public void remove (Item item){
        items.Remove(item);
    }
}
