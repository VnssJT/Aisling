using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item Databse", menuName ="Inventory System/Database")]
public class ItemDatabaseObject : ScriptableObject, ISerializationCallbackReceiver
{
    public Item[] Items;
    public Dictionary<Item, int> GetId = new Dictionary<Item, int>();
    public Dictionary<Item, int> GetId = new Dictionary<int, Item>();

    public void OnAfterDeserialize()
    {
        GetId = new Dictionary<Item, int>();
        for (int i = 0; i < Items.Length; i++)
        {   
            GetId.Add(Items[i], i);
        }
    }

    public void OnBeforeSerialize()
    {
        throw new System.NotImplementedException();
    }
}
