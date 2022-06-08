using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Player : MonoBehaviour
{
    public InventoryObject inventory;
    public GameObject notifSys;
    public ItemDatabaseObject database;
    [SerializeField] private int eventType;

    public GameObject inventoryToShow;
    public GameObject cursorToShow;
    [SerializeField] private bool inventoryOn;
    [SerializeField] private int inventoryCooldown;

    private PlayerControlls playerControlls;
    private PlayerInput playerInput;

    public GameObject gameStateManager;

    private void Start()
    {
        //controller = GetComponent<CharacterController>();
        playerControlls = this.GetComponentInParent<characterMovement>().input;
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        inventoryCooldown--; //inventoryCooldown exists to circumvent a bug that causes our inventory activation button to call the function for inventory once per update
        if (inventoryCooldown <= 0)
        {
            inventoryCooldown = 0;
        }

        if (playerControlls.Controlls.Inventory.ReadValue<float>() == 1)
        {
            Debug.Log("button press noticed");
        }

        if (playerControlls.Controlls.Inventory.ReadValue<float>() == 1 && inventoryOn && inventoryCooldown == 0) //if button defined by playerControlls is pressed and inventory open
        {
            Debug.Log("button press noticed");
            CloseInventory();
        }
        if (playerControlls.Controlls.Inventory.ReadValue<float>() == 1 && !inventoryOn && inventoryCooldown == 0) //if button defined by playerControlls is pressed and inventory closed
        {
            Debug.Log("button press noticed");
            OpenInventory();
        }
    }

    public void OnTriggerEnter(Collider other) //when player collides with objects in scene
    {
        var item = other.GetComponent<Item>(); //we get a component of the object collided with that tells us that it is an item
        var _notifSys = notifSys.GetComponent<DisplayNotifications>(); //we also setup reference to our notificationsystem
        if (item) //if that component exists and is item
        {
            eventType = 0; //eventtype for notifsystem is 0 (item pickup)
            if (item.hasFlag)
            {
                gameStateManager.GetComponent<GameStateManager>().Q1Flags[2] = true;
                eventType = 1; //eventtype for notifsystem is 0 (item pickup)
            }                        
            inventory.AddItem(item.item, 1); //add item picked up to inventory (pass arguments to the inventory.Additem() method
            Destroy(other.gameObject); //destroy gameobject in scene
            var _itemID = database.GetId[item.item]; //get itemID
            var _itemName = database.GetName[_itemID]; //get itemName (could be solved with more dictionaries, perhaps a more elegant solution exists
            _notifSys.ShowNotification(eventType, _itemName); //pass notifsystem values to the ShowNotification Method (in the DisplayNotification class attached to the notificationsystem)
        }
    }

    private void OnApplicationQuit()
    {
        inventory.Container.Clear(); //this clears the inventory after game ends, disable for testing.
    }

    private void OpenInventory()
    {
        inventoryToShow.SetActive(true);
        cursorToShow.SetActive(true);
        inventoryOn = true;
        inventoryCooldown = 300;
    }

    private void CloseInventory()
    {
        inventoryOn = false;
        cursorToShow.SetActive(false);
        inventoryToShow.SetActive(false);
        inventoryCooldown = 300;
    }
}
