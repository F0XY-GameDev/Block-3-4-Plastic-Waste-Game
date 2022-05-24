using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Default Object", menuName = "Inventory System/Items/Default")]
public class DefaultObject : ItemObject
{
    /*
    We created scriptable objects called ItemObjects in ItemObject.cs
    Here we use this scriptable object to make equipable objects with the default properties in ItemObject.cs, in case we want to make items that have no extra properties
    */
    public void Awake()
    {
        type = ItemType.Default;
    }
}
