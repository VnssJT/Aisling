using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    private void Awake() {
        if(instance != null){
            Debug.LogWarning("More than one instance of Inventory found!");
            Destroy(gameObject);
        } 
        instance = this;
    }
    #endregion

    public int space = 10;
    public List<Item> items = new List<Item>();
    public void Add(Item item){
        if(items.Count < space){
            items.Add(item);
        } else {
            Debug.Log("Not enough room");
            return;
        }
    }

    public void remove (Item item){
        items.Remove(item);
    }
}
