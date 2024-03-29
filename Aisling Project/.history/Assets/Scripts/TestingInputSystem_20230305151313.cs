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

        PlayerInputActions playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Jump.performed += Jump_performed();
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
