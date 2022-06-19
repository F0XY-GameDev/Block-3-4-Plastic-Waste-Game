using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject, ISerializationCallbackReceiver
{
    //variable for placing database object
    public ItemDatabaseObject database;

    //create a list of inventory slots
    public List<InventorySlot> Container = new List<InventorySlot>();

    //when we call the AddItem Function we pass throw an ItemObject and an Integer
    public void AddItem(ItemObject _item, int _amount)
    {
        
        for (int i = 0; i < Container.Count; i++) //for amount of items in inventory
        {
            if(Container[i].item == _item) //if the container has the item
            {
                Container[i].AddAmount(_amount); //add item amount to container with amount (calls AddAmount from line 42)
                return; //do not run more code from this function
            }
        }
        Debug.Log("before container.add");
         //we do not need an if statement here because we return before this if the item is in the inventory, and the previous code does not fire if the item is not already in inventory       
        Container.Add(new InventorySlot(database.GetId[_item], _item, _amount)); //create new item slot with _item and _amount
        
    }

    public void OnAfterDeserialize()
    {
        for (int i = 0; i < Container.Count; i++)
        {
            Container[i].item = database.GetItem[Container[i].ID];
        }
    }

    public void OnBeforeSerialize()
    {
        
    }
}

[System.Serializable] //makes the inventory slots we create visible in the editor
public class InventorySlot
{
    //each inventory slot has an ItemObject called item, an int amount, and an ID
    public int ID;
    public ItemObject item;
    public int amount;
    public InventorySlot(int _id, ItemObject _item, int _amount) //defines that an InventorySlot must be passed an ItemObject _item, and an integer _amount, and an integer ID, each will be set as the InventorySlot's own item, amount, and ID.
    {
        ID = _id;
        item = _item; 
        amount = _amount;
    }
    public void AddAmount(int value)
    {
        amount += value; //increases inventory slot amount held by amount picked up
    }
}
