using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipable Object", menuName = "Inventory System/Items/Equipable")]
public class EquipableObject : ItemObject
{    
    public float effectID1;
    public float effectID2;
    public float effectID3;
    public void Awake()
    {
        type = ItemType.Equipable;
    }
}
