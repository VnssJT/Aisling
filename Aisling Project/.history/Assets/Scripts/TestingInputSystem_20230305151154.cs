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

        new PlayerInputActions pla
    }

    private void PlayerInput_onActionTriggered(InputAction.CallbackContext context){
        Debug.Log(context);
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
