using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "I")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
}
