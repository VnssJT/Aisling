using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestingInputSystem : MonoBehaviour
{
    private PlayerInput playerInput;

    private void Awake() {
        playerInput = GetComponent<PlayerInput>();   

        PlayerInputActions playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        // Events
        playerInputActions.Player.Jump.performed += Jump_performed;
        playerInputActions.Player.Movement.performed += Movement_performed;
    }


    public void MoveUp(){
        Debug.Log("Moving up");
    }

    public void Jump_performed(InputAction.CallbackContext context){
        if(context.performed){
            Debug.Log("jump: " + context.phase);
        }
    }
}
