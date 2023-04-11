using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    Item item;
    [SerializeField] private Image icon;

    private PlayerInputActions playerInputActions;

    private void Start() {
        playerInputActions = new PlayerInputActions();
        playerInputActions.UI.Enable();
        player
    }

    public void AddItem(Item newItem){
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
