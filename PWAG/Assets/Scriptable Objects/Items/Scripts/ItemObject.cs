using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType 
{
    Evidence,
    Consumable,
    Equipable,
    Throwable,
    Default
}
public abstract class ItemObject : ScriptableObject //this scriptable object allows us to create pick-up items with some pre-defined default properties
{
    public GameObject prefab; //all items have a prefab that holds their inventory image
    public ItemType type; //an identifier for what type of item it is
    [TextArea(15,20)] //a text area for the description below
    public string description;
    public bool canRead; //a boolean that allows us to read it (WIP)
    public bool canThrow; //a boolean for whether we can throw the item or not (WIP)
    public bool canEquip; //a boolean for whether we can equip the item or not (WIP)
}
