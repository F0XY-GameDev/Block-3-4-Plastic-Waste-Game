using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InvMoveCursor : MonoBehaviour
{
    private PlayerControlls playerControls;
    private PlayerInput playerInput;
    public Vector2 RSInput;
    public float xVel;
    public float yVel;
    private Vector2 movement;
    public float cursorSpeed = 320f;
    private Rigidbody2D rb;

    public float xLocation
    {
        get { return _xLocation; }
        set { _xLocation = Mathf.Clamp(value, -176, 176); }
    } //hopefully this allows us to clamp the values of our cursor to the inventory UI
    [SerializeField, Range(0, 10)] private float _xLocation;

    public float yLocation
    {
        get { return _yLocation; }
        set { _yLocation = Mathf.Clamp(value, -162, 162); }
    } //hopefully this allows us to clamp the values of our cursor to the inventory UI
    [SerializeField, Range(0, 10)] private float _yLocation;

    private void Awake()
    {        
        playerControls = new PlayerControlls();
        playerInput = GetComponent<PlayerInput>();
    }

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        
    }
}
