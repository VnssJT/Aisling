using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    Item item;
    [serializeField] private Image 

    public void AddItem(Item newItem){
        item = newItem;
    }
}
