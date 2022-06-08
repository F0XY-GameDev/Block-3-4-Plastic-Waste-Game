using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryOptions : MonoBehaviour
{
    public GameObject inventoryOptions;

    public void SetPosition(Transform _itemSlotPos) 
    {
        inventoryOptions.transform.SetPositionAndRotation(_itemSlotPos.position, _itemSlotPos.rotation); 
        inventoryOptions.transform.SetAsLastSibling();
    }
}
