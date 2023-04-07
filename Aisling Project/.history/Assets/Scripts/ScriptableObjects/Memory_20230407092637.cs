using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memory : ScriptableObject
{
    public int MemoryID;
    public List<MemoryFragment> fragments;  // It's not empty
    public List<bool> fragmentsFound = new Lisst<bool> ()
    public int nFragments;
}
