using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transforrm itemsParent;
    Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;
    }

    // Update is called once per frame
    void UpdateUI()
    {
        Debug.Log("Uptading UI");
    }
}
