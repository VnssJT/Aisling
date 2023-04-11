using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    #region Singleton
    public static PlayerController instance;

    private void Awake() {
        if(instance != null){
            Debug.LogWarning("More than one instance of PlayerController found!");
            Destroy(gameObject);
        } 
        instance = this;
    }
    #endregion

    public delegate void OnInput();
    public OnInput onInventoryPressed;
    private PlayerInput playerInput;
    private PlayerInputActions playerInputActions;
    private string currentActionStr = "PlayerInputActions (UnityEngine.InputSystem.InputActionAsset):";
    private CharacterController characterController;

    [SerializeField] private float walkSpeed = 3f;
    [SerializeField] private float runSpeed = 20f;
    
    [SerializeField] private float animationRunSpeed = 6f;
    [SerializeField] private float gravityMultiplier = 1f;
    private float gravity = -9.18f;
    private float velocity;

    private Quaternion Rotation = Quaternion.identity;
    [SerializeField] private float playerActiveDistance = 1f;
    private float raycastYoffset = 0.5f;
    [SerializeField] private LayerMask interactiveObjectsLayer;
    private bool InteractKeyPressed = false;

    [SerializeField] Animator animator;

    private void Start() {
        playerInput = GetComponent<PlayerInput>(); 
        characterController = GetComponent<CharacterController>();  

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        // Player input actions events
        playerInputActions.Player.Interact.performed += Interact_performed;
        playerInputActions.Player.Pause.performed += Pause_Performed;
        playerInputActions.UI.Close.performed += Close_Performed;

    }

    private void Update(){
        if(playerInput.currentActionMap.ToString() == currentActionStr + "UI"){
            Debug.Log("UI activated, player doesnt move");
            return;
        }

        if(playerInput.currentActionMap.ToString() == currentActionStr + "Player"){
            
            #region Player Movement
            // Read input
            Vector2 inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
            Vector3 movement = new Vector3(inputVector.x, 0, inputVector.y);
            float currentSpeed = walkSpeed;
            animator.speed = 1f;

            // If the player is in movement
            if(movement != Vector3.zero){
                // if run key is pressed -> change speed
                if(playerInputActions.Player.Run.IsPressed()) {
                    // change movement speed
                    currentSpeed = runSpeed;

                    // change animation speed
                    animator.speed *= animationRunSpeed;
                }

                // Rotate characater
                transform.forward = movement;

                // Set animation state
                animator.SetBool("moving", true);

            } else {
                animator.SetBool("moving", false);
            }

            // Apply gravity
            velocity = characterController.isGrounded? -1f : velocity + gravity * gravityMultiplier * Time.deltaTime;
            movement.y = velocity;

            // Move character
            characterController.Move(movement * currentSpeed * Time.deltaTime);

            // Set animation direction
            animator.SetFloat("Move X", transform.forward.x);
            animator.SetFloat("Move Y", transform.forward.z);
            //Debug.Log("movement vector: " + movement);

            // Detect interative objects
            Vector3 raycastOrigin = transform.position - new Vector3(0, raycastYoffset, 0);
            RaycastHit hit;
            bool active = Physics.Raycast(raycastOrigin, transform.forward, out hit, playerActiveDistance, interactiveObjectsLayer);
            //Debug.Log("Object found (active): " + active);
            Debug.DrawRay(raycastOrigin, transform.forward, Color.red);

            // If the player is in front of an interactive object and is pessing the interact key
            if(active && InteractKeyPressed){
                InteractKeyPressed = false;
                hit.transform.TryGetComponent<InteractiveObject>(out InteractiveObject interactiveObject);
                if(interactiveObject != null){
                    interactiveObject.Interact();
                }
            }

            #endregion
        
        }

    }

    private void OnDisable() {
        // Player input actions events
        playerInputActions.Player.Interact.performed -= Interact_performed;
        playerInputActions.Player.Pause.performed -= Pause_Performed; 
    }

    public void Interact_performed(InputAction.CallbackContext context){
        InteractKeyPressed = true;
    }

    public void Pause_Performed(InputAction.CallbackContext context){
        //playerInput.actions.FindActionMap("UI").Enable();
        //playerInput.actions.FindActionMap("Player").Disable();
        playerInput.SwitchCurrentActionMap("UI");
        Debug.Log("Player actions map disabled. Enabling UI " + playerInput.currentActionMap);

        // Trigger event
        onInventoryPressed?.Invoke();
    }

    public void Close_Performed(InputAction.CallbackContext context){
        playerInput.SwitchCurrentActionMap("Player");
    }
}
