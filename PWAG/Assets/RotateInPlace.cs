using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateInPlace : MonoBehaviour
{
    public GameStateManager GSM;
    public float speed = 90.0f;  // Degrees per second;
    void Update()
    {
        var x = speed * Time.deltaTime;
        var y = speed * Time.deltaTime;

        transform.Rotate(0, y, 0);

        ControlOpacity();
    }

    public void ControlOpacity()
    {
        if (GSM.GetComponent<GameStateManager>().Q1Flags[2])
        {
            this.gameObject.SetActive(true);
            return;
        }
        if (GSM.GetComponent<GameStateManager>().Q1Flags[0])
        {
            this.gameObject.SetActive(false);
        }        
    }
}
