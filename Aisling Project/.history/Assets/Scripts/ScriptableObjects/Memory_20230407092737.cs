using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memory : ScriptableObject
{
    public int MemoryID;
    public List<MemoryFragment> fragments;  // It's not empty
    // Contains whether a fragments is found in that fragment index
    public List<bool> fragmentsFound = new List<bool>();    
    public int nFragments;
}
