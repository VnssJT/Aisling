using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestingInputSystem : MonoBehaviour
{
    private PlayerInput playerInput;
    private Rigidbody playerRigidbody;
    private PlayerInputActions play

    private void Awake() {
        playerInput = GetComponent<PlayerInput>();   
        playerRigidbody = GetComponent<Rigidbody>();

        PlayerInputActions playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        // Events
        playerInputActions.Player.Jump.performed += Jump_performed;
        playerInputActions.Player.Movement.performed += Movement_performed;
    }


    public void Movement_performed(InputAction.CallbackContext context){
        Debug.Log("Moving: " + context);
        Vector2 inputVector = context.ReadValue<Vector2>();
        float speed = 5f;
        playerRigidbody.AddForce(new Vector3(inputVector.x, 0, inputVector.y ) * speed, ForceMode.Force);
    }

    public void Jump_performed(InputAction.CallbackContext context){
        if(context.performed){
            Debug.Log("jump: " + context.phase);
        }
    }
}
