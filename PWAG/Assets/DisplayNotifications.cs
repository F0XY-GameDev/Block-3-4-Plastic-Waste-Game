using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayNotifications : MonoBehaviour
{
    public GameObject notificationSystem;
    public bool isShowing;
    public ItemDatabaseObject database;
    public TextMeshProUGUI notificationText;
    public float currentOpacity;
    public float fadeSpeed;
    public float notifFadeTimer;
    public float notifCooldown;

    void Start()
    {
        fadeSpeed = 0.005f;
        notifFadeTimer = 0.01f;
    }
    
    void Update()
    {
        OpacityControl(); //instead of clogging up our Update method, we call a seperate function in Update to handle the Notification System's opacity
    }

    public void ShowNotification(int _requiredEventType, string _optionalItemName = "nameNotPassed") //we have a required int and an optional string, this is to support different notification types later
    {        
        switch(_requiredEventType) //switch dependant on our eventtype
        {
            case 0:
                notificationText.text = "You've picked up a " + _optionalItemName; //update text 
                break;

            case 1:
                notificationText.text = "You've picked up a " + _optionalItemName + " , you should go back to the blue worker!";
                break;

            default:
                return;
        }
        currentOpacity = 1.0f;
        notifCooldown = 2.0f;

    }

    public void OpacityControl()
    {
        this.GetComponentInChildren<Image>().color = new Color(1.0f, 1.0f, 1.0f, currentOpacity); //bind our notification image to white and float currentOpacity
        this.GetComponentInChildren<TextMeshProUGUI>().alpha = currentOpacity; //bind our notification text alpha and float currentOpacity
        if (currentOpacity >= 0 && notifCooldown == 0) currentOpacity -= fadeSpeed; //if object is visible reduce currentopacity by fadespeed
        if (currentOpacity <= 0) currentOpacity = 0f; //if currentopacity is less than 0, it is 0 (could use Mathf.Clamp, will consider factors)
        if (notifCooldown >= 0) notifCooldown -= notifFadeTimer;
        if (notifCooldown <= 0) notifCooldown = 0;
    }
}
