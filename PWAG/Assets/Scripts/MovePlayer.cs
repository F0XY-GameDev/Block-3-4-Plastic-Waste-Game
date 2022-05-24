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
    public GameObject inventoryToShow;
    [SerializeField] private bool inventoryOn;
    [SerializeField] private int inventoryCooldown;

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
        inventoryCooldown --;
        if (inventoryCooldown <= 0)
        {
            inventoryCooldown = 0;
        }
        HandleInput();
        HandleMovement();

        
        if (playerControlls.Controlls.Inventory.ReadValue<float>() == 1 && inventoryOn && inventoryCooldown == 0)
        {
            CloseInventory();
        }
        if (playerControlls.Controlls.Inventory.ReadValue<float>() == 1 && !inventoryOn && inventoryCooldown == 0)
        {
            OpenInventory();
        }        
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

    private void OpenInventory()
    {
        inventoryToShow.SetActive(true);
        inventoryOn = true;
        inventoryCooldown = 300;        
    }

    private void CloseInventory()
    {        
        inventoryOn = false;
        inventoryToShow.SetActive(false);
        inventoryCooldown = 300;
    }
}

