using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestingInputSystem : MonoBehaviour
{
    public void MoveUp(){
        Debug.Log("Moving up");
    }

    public void Jump(InputAction){
        Debug.Log("jump");
    }
}
