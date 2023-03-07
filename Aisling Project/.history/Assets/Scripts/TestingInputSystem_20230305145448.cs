using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestingInputSystem : MonoBehaviour
{
    private PlayerInput playerInput;

    private void Awake() {
        playerInput = GetComponent<PlayerInput>();   

        playerInput.onActionTriggered += PlayerInput_onActionTriggered; 
    }

    private void PlayerInput_onActionTriggered(InputAction.CallbackContext obj){
        throw new System
    }

    public void MoveUp(){
        Debug.Log("Moving up");
    }

    public void Jump(InputAction.CallbackContext context){
        if(context.performed){
            Debug.Log("jump: " + context.phase);
        }
    }
}
