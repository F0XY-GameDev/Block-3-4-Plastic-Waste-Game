using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class showOnButtonPress : MonoBehaviour
{
    public GameObject objectToShow;
    public float currentOpacity;
    public bool isShowing;
    // Start is called before the first frame update
    void Start()
    {
        currentOpacity = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        objectToShow.GetComponentInChildren<Image>().color = new Color(1.0f, 1.0f, 1.0f, currentOpacity);
        if (Input.GetKeyDown("joystick button 6") && !isShowing)
        {
            currentOpacity = 1.0f;
        } 
        if (Input.GetKeyDown("joystick button 1") && isShowing)
        {
            currentOpacity = 0f;
        }
    }
}
