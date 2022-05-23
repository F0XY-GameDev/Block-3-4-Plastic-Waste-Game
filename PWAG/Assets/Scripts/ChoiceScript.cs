using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChoiceScript : MonoBehaviour
{
    public GameObject TextBox;
    public GameObject Choice1;
    public GameObject Choice2;
    public GameObject Choice3;
    public int ChoiceMade;

    public void ChoiceOption1()
    {
        TextBox.GetComponent<Text>().text = "You have chosen the 1st option";
        ChoiceMade = 1;
    }

    public void ChoiceOption2()
    {
        TextBox.GetComponent<Text>().text = "You have chosen the 2nd option";
        ChoiceMade = 2;
    }

     public void ChoiceOption3()
    {
        TextBox.GetComponent<Text>().text = "You have chosen the 3rd option";
        ChoiceMade = 3;
    }
    void Update()
    {
        if(ChoiceMade >=1)
        {
            Choice1.SetActive (false);
            Choice2.SetActive (false);
            Choice3.SetActive (false);
        }
    }
}