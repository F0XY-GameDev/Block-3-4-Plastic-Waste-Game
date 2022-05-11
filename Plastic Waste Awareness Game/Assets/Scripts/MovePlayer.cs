using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerInput))]
public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private float controllerDeadzone = 0.1f;
    [SerializeField] private float Gamepadrotatesmoothing = 1000f;

    [SerializeField] private bool isGamepad;

    private CharacterController controller;

    private Vector2 movement;
    
    private Vector3 playerVelocity;

    private PlayerControlls playerControlls;
    private PlayerInput playerInput;



    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerControlls = new PlayerControlls();
        playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        playerControlls.Enable();
    }

    private void OnDisable()
    {
        playerControlls.Disable();
    }

    void Update()
    {
        HandleInput();
        HandleMovement();
       
    }

    void HandleInput()
    {
        movement = playerControlls.Controlls.Movement.ReadValue<Vector2>();
    }

    void HandleMovement()
    {
        Vector3 move = new Vector3(movement.x, 0, movement.y);
        controller.Move(move * Time.deltaTime * playerSpeed);
    }

   
}

