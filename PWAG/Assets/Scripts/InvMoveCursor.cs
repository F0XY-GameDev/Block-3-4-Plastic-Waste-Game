using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InvMoveCursor : MonoBehaviour
{
    public float xLocation
    {
        get { return _xLocation; }
        set { _xLocation = Mathf.Clamp(value, -176, 176); }
    } //hopefully this allows us to clamp the values of our cursor to the inventory UI
    [SerializeField, Range(0, 10)] private float _xLocation;

    public float yLovation
    {
        get { return _yLocation; }
        set { _yLocation = Mathf.Clamp(value, -162, 162); }
    } //hopefully this allows us to clamp the values of our cursor to the inventory UI
    [SerializeField, Range(0, 10)] private float _yLocation;

    [SerializeField] private float cursorSpeed = 250f;
    [SerializeField] private float cControllerDeadzone = 0.1f;
    [SerializeField] private float cGamepadrotatesmoothing = 1000f;

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

    private void Update()
    {
        HandleInput();
        HandleMovement();
    }

    void HandleInput()
    {
        movement = playerControlls.Controlls.Cursor.ReadValue<Vector2>();
    }

    void HandleMovement()
    {
        Vector3 move = new Vector3(movement.x, movement.y, 0);
        controller.Move(move * Time.deltaTime * cursorSpeed);
    }
}
