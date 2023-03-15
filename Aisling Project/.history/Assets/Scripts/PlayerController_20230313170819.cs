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
        if(movement)
    }

    private void FixedUpdate(){



        Vector3 desiredForward = Vector3.RotateTowards (transform.forward, movement, rotationSpeed * Time.deltaTime, 0f);
        Rotation = Quaternion.LookRotation (desiredForward);        
        transform.Rotate(Rotation);
        //playerRigidbody.AddForce(new Vector3(inputVector.x, 0, inputVector.y ) * speed, ForceMode.Force);
    }
}
