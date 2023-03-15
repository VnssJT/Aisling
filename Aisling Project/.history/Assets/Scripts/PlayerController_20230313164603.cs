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
        characterController.Rotate


                this.rotation = new Vector3(0, Input.GetAxisRaw("Horizontal") * _rotationSpeed * Time.deltaTime, 0);
 
        Vector3 move = new Vector3(0, 0, Input.GetAxisRaw("Vertical") * Time.deltaTime);
        move = this.transform.TransformDirection(move);
        _controller.Move(move * _speed);
        this.transform.Rotate(this.rotation);
        //playerRigidbody.AddForce(new Vector3(inputVector.x, 0, inputVector.y ) * speed, ForceMode.Force);
    }
}
