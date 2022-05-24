using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Evidence Object", menuName = "Inventory System/Items/Evidence")]
public class EvidenceObject : ItemObject
{    
    [TextArea(15,20)]
    public string evidenceText;
    public void Awake()
    {
        type = ItemType.Evidence;
    }
}
