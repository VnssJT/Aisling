using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Iventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;

    public virtual void Use(){
        // Use the item
        // Something might happen

        Debug.Log("Using")
    }
}
