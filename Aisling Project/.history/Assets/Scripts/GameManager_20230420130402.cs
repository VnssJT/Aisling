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
        
    }

    void MemoryManager_OnGreenFound(){
        Debug.Log("GAME MANAGER: green found lol");
    }
}
