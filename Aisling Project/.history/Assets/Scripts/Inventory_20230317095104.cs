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
    }

    #endregion
    
    public List<Item> items = new List<Item>();
    public void Add(Item item){
        items.Add(item);
    }

    public void remove (Item item){
        items.Remove(item);
    }
}
