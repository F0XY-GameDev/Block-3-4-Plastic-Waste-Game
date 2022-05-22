using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{

     public static bool gameOver;
    public GameObject Caught;//referencing the game over object
    // Start is called before the first frame update
    void Start()
    {
         gameOver = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //calling the game over panel
        if(gameOver)
        {
            Time.timeScale = 0;
            Caught.SetActive(true);
        }
    }
}
