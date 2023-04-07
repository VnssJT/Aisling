using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New memory fragment", menuName = "Iventory/Item")]
public class Memory : ScriptableObject
{
    public int MemoryID;
    public List<MemoryFragment> fragments;
    public int nFragments;
}
