using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public GameObject cameraOne;
    public GameObject cameraTwo;
    public GameObject objectMazeCamera;
    
    void OnTriggerEnter()
   {
            cameraOne.SetActive(true);
            cameraTwo.SetActive(false);
            objectMazeCamera.SetActive(true);
   }
   
}


