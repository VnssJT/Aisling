using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memory : ScriptableObject
{
    public int MemoryID;    // This stores the index of the Memory Manager's list
    public List<MemoryFragment> fragments;  // It's not empty
    public List<bool> fragmentsFound = new List<bool>();    // Contains whether a fragments is found in that fragment index
    public int nFragments;

    public bool AddFragment(int fragmentIndex){
        if(!fragmentsFound[fragmentIndex]){

        }
        
        fragmentsFound[fragmentIndex] = true;
    }
}
