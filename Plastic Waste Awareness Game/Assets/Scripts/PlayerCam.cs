using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
       
    [Header("Sensitivity")]
    public float sensX;
    public float sensY;

    [Header("Game Objects To Reference")]
    public GameObject pauseMenu;
    public Transform orientation;

    [Header("Current Camera Angle")]
    public float xRotation;
    public float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;       
    }

    private void Update()
    {
        if (!pauseMenu.GetComponent<PauseMenu>().paused)
        {
            //get mouse input
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

            yRotation += mouseX;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            //rotate cam and orientation
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        }
    }
}
