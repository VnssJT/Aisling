using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New memory fragment", menuName = "Memory/Fragment")]
public class MemoryFragment : Item
{
    public MemoryManager.MemoryIndex MemoryID;
    public int FragmentID;
}
