using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSync : MonoBehaviour
{
    //Getting references to the position and size properties in the shader graph window
    public static int PosID = Shader.PropertyToID("_Position");
    public static int SizeID = Shader.PropertyToID("_Size");
    public Material WallMaterial;//we want to change the wall material
    public Camera Camera;//Camera reference
    public LayerMask Mask;//to check to collision masks
    
    void Update()
    {
        //Setting the camera
        var dir = Camera.transform.position - transform.position;
        var ray = new Ray(transform.position, dir.normalized);

        if(Physics.Raycast(ray, 3000, Mask))
    
            WallMaterial.SetFloat(SizeID, 1);
        else
            WallMaterial.SetFloat(SizeID, 0);
            
        

        var view = Camera.WorldToViewportPoint(transform.position);
        WallMaterial.SetVector(PosID, view);
    }
}
