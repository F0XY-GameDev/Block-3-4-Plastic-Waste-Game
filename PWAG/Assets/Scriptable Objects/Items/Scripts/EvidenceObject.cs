using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Evidence Object", menuName = "Inventory System/Items/Evidence")]
public class EvidenceObject : ItemObject
{
    /*
    We created scriptable objects called ItemObjects in ItemObject.cs
    Here we use this scriptable object to make evidence objects with the default properties in ItemObject.cs, but also some extra intrinsic properties for our evidence objects
    */
    [TextArea(15,20)]
    public string evidenceText;
    public void Awake()
    {
        type = ItemType.Evidence;
    }
}
