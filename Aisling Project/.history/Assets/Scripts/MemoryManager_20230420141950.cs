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
    [HideInInspector] public List<bool> memoriesFound;

    // EVENTS
    #region Events
    public delegate void MemoryAction();
    // GREEN found
    public static event MemoryAction OnGreenFound;
    // ORANGE found
    public static event MemoryAction OnOrangeFound;
    // YELLOW found
    public static event MemoryAction OnYellowFound;
    // RED found
    public static event MemoryAction OnRedFound;
    #endregion

    private void Start() {
        // Reset fragments and memories found
        memoriesFound.Clear();
        foreach (Memory memory in memories)
        {
            memory.ResetFragments();
            memoriesFound.Add(false);
        }
    }
    public void AddFragment(MemoryIndex memoryID, int fragmentID){
        Memory memory = memories[(int) memoryID];
        memory.AddFragment(fragmentID);

        // Check if it's the last fragment
        foreach(bool fragmentFound in memory.fragmentsFound){
            if(!fragmentFound){
                return;
            }
        }

        // All of the fragments were found
        Debug.Log("MEMORY MANAGER: memories found count")
        memoriesFound[(int) memoryID] = true;
        //Debug.Log("MEMORY MANAGER: memory " + memoryID + " found");

        // Check if the memory is a gameplay trigger
        switch (memoryID)
        {
            case MemoryIndex.GREEN:
                OnGreenFound?.Invoke();
                break;

            case MemoryIndex.ORANGE:
                OnOrangeFound?.Invoke();
                break;

            case MemoryIndex.YELLOW:
                OnYellowFound?.Invoke();
                break;

            case MemoryIndex.RED:
                OnRedFound?.Invoke();
                break;

            default:
                break;
        }
    }

}
