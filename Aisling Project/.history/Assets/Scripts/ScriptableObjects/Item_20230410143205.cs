using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory System/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public string description

    public virtual void Use(){
        // Use the item
        // Something might happen

        Debug.Log("Using" + name);
    }
}
