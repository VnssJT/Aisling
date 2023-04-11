using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabaseObject : ScriptableObject
{
    public Item[] Items;
    public Dictionary<Item, int> GetId = new Dictionary<Item, int>();
}
