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
    //[SerializeField] private float rotationSpeed = 200f;
    [SerializeField] private float gravityMultiplier = 1f;
    private float gravity = -9.18f;
    private float velocity;

    private Quaternion Rotation = Quaternion.identity;
    [SerializeField] private float playerActiveDistance = 1f;
    private float raycastYoffset = 0.5f;
    [SerializeField] private LayerMask interactiveObjectsLayer;
    private bool InteractKeyPressed = false;
    private void Awake() {
        playerInput = GetComponent<PlayerInput>(); 
        characterController = GetComponent<CharacterController>();  

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        // Player input actions events
        playerInputActions.Player.Interact.performed += Interact_performed;
        //playerInputActions.Player.Interact.canceled += Interact_canceled;

    }

    private void Update(){
        // Read input
        Vector2 inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
        Vector3 movement = new Vector3(inputVector.x, 0, inputVector.y);

        // Rotate characater
        if(movement != Vector3.zero){
            if(playerInputActions.Player.Run.)
            transform.forward = movement;
        }

        // Apply gravity
        velocity = characterController.isGrounded? -1f : velocity + gravity * gravityMultiplier * Time.deltaTime;
        movement.y = velocity;

        // Move character
        characterController.Move(movement * walkSpeed * Time.deltaTime);

        // Detect interative objects
        Vector3 raycastOrigin = transform.position - new Vector3(0, raycastYoffset, 0);
        RaycastHit hit;
        bool active = Physics.Raycast(raycastOrigin, transform.forward, out hit, playerActiveDistance, interactiveObjectsLayer);
        //Debug.Log("Object found (active): " + active);
        //Debug.DrawRay(raycastOrigin, transform.forward, Color.red);

        // If the player is in front of an interactive object and is pessing the interact key
        if(active && InteractKeyPressed){
            InteractKeyPressed = false;
            hit.transform.TryGetComponent<InteractiveObject>(out InteractiveObject interactiveObject);
            if(interactiveObject != null){
                interactiveObject.Interact();
            }
        }
    }

    public void Interact_performed(InputAction.CallbackContext context){
        InteractKeyPressed = true;
    }

    public void Interact_canceled(InputAction.CallbackContext context){
        InteractKeyPressed = false;
    }
}
