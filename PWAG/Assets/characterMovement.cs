using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class characterMovement : MonoBehaviour
{
    Animator animator; //animator component
    public RuntimeAnimatorController crouchActive;
    public RuntimeAnimatorController normalActive;

    int isWalkingHash;
    int isRunningHash;
    int isCrouchingHash;
    int  hasStoppedHash;

    public PlayerControlls input;//reference to the Input System script

    Vector2 curentMovement;
    bool movementPressed;
    bool runPressed;

    void Awake()
    {
        //Storing input values
        input = new PlayerControlls();//using the input map

        input.Controlls.Movement.performed += ctx => 
        {
            curentMovement = ctx.ReadValue<Vector2>();
            movementPressed = curentMovement.x != 0 || -curentMovement.y != 0;
        };
        input.Controlls.Run.performed += ctx => runPressed = ctx.ReadValueAsButton();
    }
    void Start()
    {
        animator = GetComponent<Animator>();

        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        isCrouchingHash = Animator.StringToHash("isCrouching");
    }

    
    void Update()
    {
        handleMovement();
        handleRotation();
        
    }

    void CrouchMode()
    {
        bool isCrouching= animator.GetBool(isCrouchingHash);
        animator.SetTrigger(isCrouchingHash);
    }
    void handleRotation()
    {
        //current position of our character
        Vector3 currentPosition = transform.position;
        
        //change the position our character should point to
        Vector3 newPosition = new Vector3(curentMovement.x, 0, curentMovement.y);

        //combine the positon to give a position to look at
        Vector3 positionToLookAt = currentPosition + newPosition;

        //rotate the character to face the position to look at
        transform.LookAt(positionToLookAt);
    }
    void handleMovement()
    {
        bool isRunning = animator.GetBool(isRunningHash);
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isCrouching= animator.GetBool(isCrouchingHash);


        //start walking if movement pressed is true and already not walking
        if (movementPressed && !isWalking)
        {
            animator.SetBool(isWalkingHash, true);
        }

        //stop walking if movement pressed is false and not already walking
        if (!movementPressed && isWalking)
        {
            animator.SetBool(isWalkingHash, false);
        }

        if ((movementPressed && runPressed) && !isRunning)
        {
            animator.SetBool(isRunningHash, true);
        }

        if ((!movementPressed || !runPressed) && isRunning)
        {
            animator.SetBool(isRunningHash, false);
        }
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "CrouchSwitch")
        {
            animator.runtimeAnimatorController = crouchActive as RuntimeAnimatorController;
        }
        if(other.name =="NormalSwitch")
        {
            animator.runtimeAnimatorController = normalActive as RuntimeAnimatorController;
        }

    }

    void OnEnable()
    {
        //Enable the controlls action map
        input.Controlls.Enable();
    }

    void OnDisable()
    {
        //Disable the controlls action map
        input.Controlls.Disable();
    }
}
