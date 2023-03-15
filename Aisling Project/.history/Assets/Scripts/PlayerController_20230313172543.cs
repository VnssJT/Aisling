using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInputActions playerInputActions;
    private CharacterController characterController;

    [SerializeField] private float walkSpeed = 3f;
    [SerializeField] private float rotationSpeed = 200f;
    [SerializeField] private float gravityMul
    private float gravity = -9.18f;

    private Quaternion Rotation = Quaternion.identity;
    private void Awake() {
        playerInput = GetComponent<PlayerInput>(); 
        characterController = GetComponent<CharacterController>();  

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

    }

    private void Update(){
        Vector2 inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
        Vector3 movement = new Vector3(inputVector.x, 0, inputVector.y);
        characterController.Move(movement * walkSpeed * Time.deltaTime);
        if(movement != Vector3.zero){
            transform.forward = movement;
        }
    }
}
