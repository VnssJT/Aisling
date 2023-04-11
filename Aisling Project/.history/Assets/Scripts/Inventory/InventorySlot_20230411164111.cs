using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class InventorySlot : MonoBehaviour
{
    public Item item;
    [SerializeField] private Image icon;

    public void AddItem(Item newItem){
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
