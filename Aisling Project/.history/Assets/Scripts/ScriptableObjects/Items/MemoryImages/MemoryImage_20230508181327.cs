using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New memory imagw", menuName = "Memory/Memory")]
public class MemoryImage : ScriptableObject
{
    public MemoryManager.MemoryIndex memoryID;
    public int nImages;
}
