using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabaseObject : ScriptableObject, ISerializationCallbackReceiver
{
    public Item[] Items;
    public Dictionary<Item, int> GetId = new Dictionary<Item, int>();

    public void OnAfterDeserialize()
    {
        GetId = new 
    }

    public void OnBeforeSerialize()
    {
        throw new System.NotImplementedException();
    }
}