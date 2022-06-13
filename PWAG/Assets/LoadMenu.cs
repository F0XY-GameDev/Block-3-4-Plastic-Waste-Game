using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
    }
}
