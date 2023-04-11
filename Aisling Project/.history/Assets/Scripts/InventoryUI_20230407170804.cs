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

        slots = itemsParent.Get
    }

    // Update is called once per frame
    void UpdateUI()
    {
        Debug.Log("Uptading UI");
    }
}
