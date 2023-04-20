using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // IMPORTANT EVENTS
    // When VIOLET, CYAN and GREEN memory are found -> open puzzle 1
    // When puzzle 1 solve -> grant access to school
    // When BLUE and ORANGE memories are found -> open puzzle 2
    // When puzzle 2 solved -> grant access to apartments
    // When YELLOW found -> create maze
    // When RED found -> grant access to LIMBO

    // Start is called before the first frame update
    void Start()
    {
        MemoryManager.OnGreenFound += MemoryManager_OnGreenFound;
        MemoryManager.OnOrangeFound += MemoryManager_OnOrangeFound;
        MemoryManager.OnYellowFound += MemoryManager_OnYellowFound;
        MemoryManager.OnRedFound += MemoryManager_OnRedFound;
    }

    void MemoryManager_OnGreenFound(){
        // Check if VIOLET and CYAN were found
        MemoryManager.instance.memoriesFound[MemoryManager.MemoryIndex.VIOLET] 
        Debug.Log("GAME MANAGER: green found lol");
    }

    void MemoryManager_OnOrangeFound(){
        Debug.Log("GAME MANAGER: orange found lol");
    }

    void MemoryManager_OnYellowFound(){
        Debug.Log("GAME MANAGER: yellow found lol");
    }

    void MemoryManager_OnRedFound(){
        Debug.Log("GAME MANAGER: red found lol");
    }
}
