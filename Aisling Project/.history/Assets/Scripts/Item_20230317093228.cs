using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Iventory")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
}
