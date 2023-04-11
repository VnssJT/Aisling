using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MemoryManager : MonoBehaviour
{

    #region Singleton
    public static MemoryManager instance;

    public enum MemoryIndex
{
    VIOLET,
    BLUE,
    CYAN,
    GREEN,
    YELLOW,
    ORANGE,
    RED
}


    private void Awake() {
        if(instance != null){
            Debug.LogWarning("More than one instance of Memory Manager found!");
            Destroy(gameObject);
        } 
        instance = this;
    }
    #endregion

    public List<Memory> memories;

    private void Start() {
        // Reset fragments found
        foreach (Memory memory in memories)
        {
            memory.ResetFragments();
        }
    }
    public void AddFragment(int memoryID, int fragmentID){
        memories[memoryID].AddFragment(fragmentID);
    }

}
