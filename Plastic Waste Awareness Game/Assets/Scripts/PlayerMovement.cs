using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Speed")]

    public float moveSpeed;
    public float maxMoveSpeed;

    [Header("Anti-Normal Forces")]

    public float groundDrag;
    public float groundDragConst;    
    public float gravity;

    [Header("Air/Slide Movement-Freedom")]

    public float airMultiplier;
    public float slideMultiplier;

    [Header("Jump Modifiers")]

    public float jumpForce;
    public float jumpForceForward;
    public float jumpCooldown;
    public float doubleJumpForce;
    public bool readyToJump;
    public bool readyToDoubleJump;
    public float doubleJumpCooldown;

    [Header("Super Jump Modifiers")]

    public float superJumpForce;
    public float superJumpCooldown;
    public bool readyToSuperJump;

    [Header("Slide Modifiers")]

    public float slideForceDown;
    public float slideForceForward;    
    public float slideCooldown;
    public bool sliding;
    public bool readyToSlide;

    [Header("GameObjects")]

    public Transform orientation;
    public Text speedText;

    [Header("Keybinds")]

    public KeyCode superJumpKey = KeyCode.E;
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode slideKey = KeyCode.LeftControl;

    [Header("Ground Check")]

    public float playerHeight;
    public LayerMask whatIsGround;
    public bool grounded;

    

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        if (sliding)
        {
            groundDrag = 1f;
        }
        else groundDrag = groundDragConst;


        speedText.text = "Speed:" + Mathf.Sqrt(Mathf.Pow(rb.velocity.x, 2f) + Mathf.Pow(rb.velocity.z, 2f)); 
        //ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.4f, whatIsGround);

        MyInput();
        SpeedControl();

        //handle drag
        if (grounded)
            rb.drag = groundDrag;        
        else
            rb.drag = 0.5f * groundDrag;
    }

    private void FixedUpdate()
    {
        
        MovePlayer();

        if (!grounded)
        rb.AddForce(Vector3.down * gravity * rb.mass, ForceMode.Acceleration);

    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // when to jump 
        if (Input.GetKeyDown(jumpKey) && readyToJump)
        {
            if (Input.GetKey(jumpKey) && readyToDoubleJump && !grounded)
            {
                readyToDoubleJump = false;

                DoubleJump();

                Invoke(nameof(ResetDoubleJump), doubleJumpCooldown);
            }
            else if (Input.GetKey(jumpKey) && readyToJump && grounded)
            {
                readyToJump = false;

                Jump();

                Invoke(nameof(ResetJump), jumpCooldown);
            }
        }

        // when to slide
        if(Input.GetKeyDown(slideKey) && readyToSlide)
        {
            readyToSlide = false;

            Slide();

            Invoke(nameof(ResetSlide), slideCooldown);
        }

        // when to super jump
        if(Input.GetKeyDown(superJumpKey) && readyToSuperJump && grounded)
        {
            readyToSuperJump = false;

            SuperJump();

            Invoke(nameof(ResetSuperJump), superJumpCooldown);
        }
    }
    
    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // on ground
        if(grounded)
            if (sliding)
                rb.AddForce(moveDirection.normalized * moveSpeed * 7f * slideMultiplier, ForceMode.Force);
            else
                rb.AddForce(moveDirection.normalized * moveSpeed * 7f, ForceMode.Force);

        // in air
        else if(!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 5f * airMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatvel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //limit velocity if needed     
        if (flatvel.magnitude > maxMoveSpeed)
        {
            Vector3 limitedvel = flatvel.normalized * maxMoveSpeed;
            rb.velocity = new Vector3(limitedvel.x, rb.velocity.y, limitedvel.z);
        }

    }

    private void Jump()
    {
        //reset y velocity 
        
        if (sliding)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        } else
        {
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        }

        rb.AddForce(moveDirection.normalized * jumpForceForward, ForceMode.Impulse);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }

    private void DoubleJump()
    {
        //reset vertical velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(moveDirection.normalized * jumpForceForward, ForceMode.Impulse);
        rb.AddForce(transform.up * doubleJumpForce, ForceMode.Impulse);
    }

    private void ResetDoubleJump()
    {
        readyToDoubleJump = true;
    }

    private void Slide()
    {
        sliding = true;
        rb.AddForce(Vector3.down * slideForceDown, ForceMode.Impulse);
        rb.AddForce(Vector3.down * slideForceDown, ForceMode.Force);
        rb.AddForce(moveDirection.normalized * slideForceForward, ForceMode.Impulse);
    }

    private void ResetSlide()
    {
        sliding = false;
        Invoke(nameof(SlideOffCooldown), 2f);

    }

    private void SlideOffCooldown()
    {
        readyToSlide = true;
    }

    private void SuperJump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(Vector3.up * superJumpForce, ForceMode.Impulse);

    }

    private void ResetSuperJump()
    {
        readyToSuperJump = true;
    }
}
