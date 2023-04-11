using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New memory fragment", menuName = "Memory/fragment")]
public class MemoryFragment : Item
{
    public MemoryManager.MemoryIndex MemoryID;
    public int FragmentID;
}
