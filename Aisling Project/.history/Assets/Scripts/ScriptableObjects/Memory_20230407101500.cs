using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New memory ", menuName = "Memory/Memory")]
public class Memory : ScriptableObject
{
    public int MemoryID;    // This stores the index of the Memory Manager's list
    public List<MemoryFragment> fragments;  // It's not empty
    public List<bool> fragmentsFound = new List<bool>();    // Contains whether a fragments is found in that fragment index
    public int nFragments;

    public bool AddFragment(int fragmentIndex){
        if(fragmentsFound[fragmentIndex]){
            Debug.Log("M: " + MemoryID + ". F: " + fragmentIndex + " is already found");
            return false;
        }

        Debug.Log("M: " + MemoryID + ". F: " + fragmentIndex + " added");
        fragmentsFound[fragmentIndex] = true;
        return true;
    }

    public void ResetFragments(){
        foreach (var item in fragmentsFound)
        {  
            
        }
    }
}
