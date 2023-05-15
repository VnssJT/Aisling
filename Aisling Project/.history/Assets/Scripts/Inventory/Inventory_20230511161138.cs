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
        DontDestroyOnLoad(gameObject);
        Debug.Log("INVENTORY")
    }
    #endregion
    
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    public int space = 10;
    public List<Item> items = new List<Item>();
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

    public void deleteFragments(MemoryManager.MemoryIndex memoryID){
        // search all of the fragments with this memoryID
        for(int i=items.Count - 1; i > -1; i--){
            if(items[i] is MemoryFragment && (items[i] as MemoryFragment).MemoryID == memoryID){
                // Delete them
                remove(items[i]);
            }
        }
    }

    
}