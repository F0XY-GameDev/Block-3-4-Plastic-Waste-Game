using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject cameraOne;
    public GameObject cameraTwo;
    public GameObject objectNormalCamera;
    
    void OnTriggerEnter()
   {
            cameraOne.SetActive(false);
            cameraTwo.SetActive(true);
            objectNormalCamera.SetActive(true);
   }
   
}
