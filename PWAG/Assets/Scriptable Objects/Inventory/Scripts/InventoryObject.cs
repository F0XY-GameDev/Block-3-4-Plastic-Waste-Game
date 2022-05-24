using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    //create a list of inventory slots
    public List<InventorySlot> Container = new List<InventorySlot>();

    //when we call the AddItem Function we pass throw an ItemObject and an Integer
    public void AddItem(ItemObject _item, int _amount)
    {
        bool hasItem = false;
        for (int i = 0; i < Container.Count; i++) //for amount of items in inventory
        {
            if(Container[i].item == _item) //if the container has the item
            {
                Container[i].AddAmount(_amount); //add item amount to container with amount (calls AddAmount from line 42)
                hasItem = true; 
                break;
            }
        }
        if(!hasItem) //if new item
        {
            Container.Add(new InventorySlot(_item, _amount)); //create new item slot with _item and _amount
        }
    }
}

[System.Serializable] //makes the inventory slots we create visible in the editor
public class InventorySlot
{
    //each inventory slot has an ItemObject called item, and an integer for amount
    public ItemObject item;
    public int amount;
    public InventorySlot(ItemObject _item, int _amount) //defines that an InventorySlot must be passed an ItemObject _item, and an integer _amount, both will be set as the InventorySlot's own item and amount ItemObject and Amount, respectively
    {
        item = _item; 
        amount = _amount;
    }
    public void AddAmount(int value)
    {
        amount += value; //increases inventory slot amount held by amount picked up
    }
}
