using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New memory image", menuName = "Memory/Memory")]
public class MemoryImage : ScriptableObject
{
    public MemoryManager.MemoryIndex memoryID;
    public int nImages;
}