using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerialiseField] private Transform itemsParent;
    Inventory inventory;
    InventorySlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void UpdateUI()
    {
        Debug.Log("Uptading UI");
        // For all of the inventory slots
        for (int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.items.Count){

            }
        }
    }
}
