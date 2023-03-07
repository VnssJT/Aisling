using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInputActions playerInputActions;
    private CharacterController characterController;

    [SerializeField] private float walkSpeed = 2f;

    private void Awake() {
        playerInput = GetComponent<PlayerInput>(); 
        characterController = GetComponent<CharacterController>();  

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

    }

    private void Update(){
    }

    private void FixedUpdate(){
        Vector2 inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
        characterController.Move(new Vector3(inputVector.x, 0, inputVector.y ) * walkSpeed * Time.deltaTime);
        //playerRigidbody.AddForce(new Vector3(inputVector.x, 0, inputVector.y ) * speed, ForceMode.Force);
    }
}
