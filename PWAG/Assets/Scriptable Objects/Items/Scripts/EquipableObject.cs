using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipable Object", menuName = "Inventory System/Items/Equipable")]
public class EquipableObject : ItemObject  
{
    /*
    We created scriptable objects called ItemObjects in ItemObject.cs
    Here we use this scriptable object to make equipable objects with the default properties in ItemObject.cs, but also some extra intrinsic properties for our equipable objects
    */
    public int effectID1;
    public int effectID2;
    public int effectID3;
    public void Awake()
    {
        type = ItemType.Equipable;
    }
}
