using UnityEngine;

public class InventoryUI : MonoBehaviour, ISerializationCallbackReceiver
{
    [SerializeField] private Transform itemsParent;
    Inventory inventory;
    InventorySlot[] slots;
    [SerializeField] private GameObject inventoryUI;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;
        PlayerController.instance.onInventoryPressed += DisplayUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    private void OnDisable() {
        inventory.onItemChangedCallback -= UpdateUI;
        PlayerController.instance.onInventoryPressed -= DisplayUI;
    }

    // Update is called once per frame
    void UpdateUI()
    {
        //Debug.Log("Uptading UI");
        // For all of the inventory slots
        for (int i = 0; i < slots.Length; i++)
        {
            // If there are some items to add
            if(i < inventory.items.Count){
                slots[i].AddItem(inventory.items[i], inventory.database.GetId[inventory.items[i]]);
            } else {
                slots[i].ClearSlot();
            }
        }
    }

    private void DisplayUI(){
        inventoryUI.SetActive(!inventoryUI.activeSelf);
    }

    public void OnAfterDeserialize(){
        for (int i = 0; i < inventory.items.Count; i++)
        {
            
        }
    }

    public void OnBeforeSerialize(){}
}
