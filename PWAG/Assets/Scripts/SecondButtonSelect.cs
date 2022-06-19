using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondButtonSelect : MonoBehaviour
{
    public Button primaryButton;     // Start is called before the first frame update
    void OnEnable()
    {
        primaryButton.Select();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
