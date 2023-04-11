using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : Scip
{
    #region Singleton
    public static Inventory instance;

    private void Awake() {
        if(instance != null){
            Debug.LogWarning("More than one instance of Inventory found!");
            Destroy(gameObject);
        } 
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    public int space = 10;
    public List<Item> items = new List<Item>();
    public ItemDatabaseObject database;
    public bool Add(Item item){
        
        if(items.Count < space){
            items.Add(item);
            onItemChangedCallback?.Invoke();
            return true;
        } 

        Debug.Log("Not enough room");
        return false;
        
    }

    public void remove (Item item){
        items.Remove(item);
    }
}
