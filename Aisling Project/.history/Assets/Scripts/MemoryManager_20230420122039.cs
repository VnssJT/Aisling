using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MemoryManager : MonoBehaviour
{

    #region Singleton
    public static MemoryManager instance;

    private void Awake() {
        if(instance != null){
            Debug.LogWarning("More than one instance of Memory Manager found!");
            Destroy(gameObject);
        } 
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    #endregion

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

    public List<Memory> memories;
    public List<bool> memoriesFound;

    private void Start() {
        // Reset fragments found
        for (int i = 0; i < memories.Count; i++)
        {
            memories[i].ResetFragments();
            memoriesFound[i].Add(false)
        }
    }
    public void AddFragment(MemoryIndex memoryID, int fragmentID){
        memories[(int) memoryID].AddFragment(fragmentID);
    }

}
