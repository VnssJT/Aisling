using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public List<Item> items = new List<Item>();

    private void Awake() {
        if(instance != null){
            Debug.LogWarning(MotionVectorGenerationMode th)
        }
    }

    public void Add(Item item){
        items.Add(item);
    }

    public void remove (Item item){
        items.Remove(item);
    }
}
