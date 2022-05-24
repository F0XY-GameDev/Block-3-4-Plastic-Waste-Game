using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayInventory : MonoBehaviour
{
    //declare an InventoryObject to display, and some properties of the display that we can adjust as necessary
    public InventoryObject inventory;
    public int X_START;
    public int Y_START;
    public int X_SPACE_BETWEEN_ITEMS;
    public int NUMBER_OF_COLUMN;
    public int Y_SPACE_BETWEEN_ITEMS;
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>(); 
    
    void Start()
    {
        CreateDisplay(); //call function to create inventoryscreen on start
    }
        
    void Update()
    {
        UpdateDisplay(); //call function to update inventoryscreen whenever Update is ticking
    }
    public void UpdateDisplay()
    {
        for(int i = 0; i < inventory.Container.Count; i++) //for amount of inventory slots
        {
            if (itemsDisplayed.ContainsKey(inventory.Container[i])) //if the item in the inventory has already been added to the inventoryscreen
            {
                itemsDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0"); //set amount to the amount in inventory 
            }
            else
            {
                var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform); //create inventory object from prefab
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i); //set location based on Vector3 GetPosition below
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0"); //set text from prefab to amount of item held as string
                itemsDisplayed.Add(inventory.Container[i], obj); //add item displayed to itemsDisplayed Dictionary (prevents re-rendering already rendered items)
            }
        }
    }
    public void CreateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++) //for amount of inventory slots
        {
            var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform); //create inventory object from prefab
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i); //set location based on Vector3 GetPosition below
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0"); //set text from prefab to amount of item held as string
            itemsDisplayed.Add(inventory.Container[i], obj); //add item displayed to itemsDisplayed Dictionary (prevents re-rendering already rendered items)
        }
    }
    public Vector3 GetPosition(int i)
    {
        return new Vector3(X_START + (X_SPACE_BETWEEN_ITEMS *(i % NUMBER_OF_COLUMN)),Y_START + (-Y_SPACE_BETWEEN_ITEMS * (i/NUMBER_OF_COLUMN)), 0f); //returns a Vector3 position based on the starting values we set earlier modified by the amount of items we have already rendered in the inventory
    }
}
