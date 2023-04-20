using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New memory ", menuName = "Memory/Memory")]
public class Memory : ScriptableObject
{
    public MemoryManager.MemoryIndex MemoryID;    // This stores the index of the Memory Manager's list
    public List<MemoryFragment> fragments;  // It's not empty
    public List<bool> fragmentsFound = new List<bool>();    // Contains whether a fragments is found in that fragment index
    public int nFragments;

    public bool AddFragment(int fragmentIndex){
        // If fragment wasalready found
        if(fragmentsFound[fragmentIndex]){
            //Debug.Log("M: " + MemoryID + ". F: " + fragmentIndex + " is already found");
            return false;
        }

        // If it wans't found
        //Debug.Log("M: " + MemoryID + ". F: " + fragmentIndex + " added");
        fragmentsFound[fragmentIndex] = true;
        
        // Check if it's the last fragment
        

        return true;
    }

    public void ResetFragments(){
        for (int i = 0; i < nFragments; i++)
        {
            fragmentsFound[i] = false;
        }
    }
}
