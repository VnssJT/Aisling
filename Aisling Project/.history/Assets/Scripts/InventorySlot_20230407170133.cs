using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    Item item;
    [serializeField] private Image icon;

    public void AddItem(Item newItem){
        item = newItem;
        icon.Sprite = item.icon;
    }
}
