using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestingInputSystem : MonoBehaviour
{
    private PlayerInput playerInput;
    private Rigidbody playerRigidbody;
    private PlayerInputActions playerInputActions;

    private void Awake() {
        playerInput = GetComponent<PlayerInput>();   
        playerRigidbody = GetComponent<Rigidbody>();

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        // Events
        playerInputActions.Player.Jump.performed += Jump_performed;
        playerInputActions.UI.Submit.performed += Submit_performed;
    }

    private void Update(){
        if(Keyboard.current.tKey.wasPressedThisFrame){
            playerInput.SwitchCurrentActionMap("UI");
        }
        if(Keyboard.current.yKey.wasPressedThisFrame){
            playerInput.SwitchCurrentActionMap("Player");
        }
    }

    private void FixedUpdate(){
        Vector2 inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
        float speed = 1f;
        playerRigidbody.AddForce(new Vector3(inputVector.x, 0, inputVector.y ) * speed, ForceMode.Force);
    }

    public void Jump_performed(InputAction.CallbackContext context){
        if(context.performed){
            Debug.Log("jump: " + context.phase);
        }
    }

    public void Submit_performed(InputAction.CallbackContext context){
        Debug.Log("Submit " + context);
    }
}
