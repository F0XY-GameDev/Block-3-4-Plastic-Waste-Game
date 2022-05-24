using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Throwable Object", menuName = "Inventory System/Items/Throwable")]
public class ThrowableObject : ItemObject
{
    /*
    We created scriptable objects called ItemObjects in ItemObject.cs
    Here we use this scriptable object to make throwable objects with the default properties in ItemObject.cs, but also some extra intrinsic properties for our throwable objects
    */
    public int effectID1;
    public float throwDistance;
    public void Awake()
    {
        type = ItemType.Throwable;
    }
}
