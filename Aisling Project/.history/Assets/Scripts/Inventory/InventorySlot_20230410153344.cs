using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Item item {get; private set;}
    [SerializeField] private Image icon;
    public int ID;

    public void AddItem(Item newItem, int newID){
        ID = newID;
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void ClearSlot(){
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }

    public void UseItem(){
        if(item != null){
            item.Use();
        }
    }
}
