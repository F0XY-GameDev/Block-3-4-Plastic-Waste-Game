using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CursorCollision : MonoBehaviour
{
    GameObject selectedItem;
    public GameObject inventoryScreen;
    public int itemID;
    public string itemDescription;
    public string itemName;
    public Sprite itemSprite;
    public ItemDatabaseObject database;
    private GameObject g;
    public Image itemImage;
    public TextMeshProUGUI _itemName;
    public TextMeshProUGUI _itemDescription;
    
    // Start is called before the first frame update
    public void OnControllerColliderHit(Collider2D other)
    {
        g = other.transform.parent.gameObject;
        itemID = g.GetComponent<ItemID>().ID;
        Debug.Log("trigger");
    }

    // Update is called once per frame
    void Update()
    {
        if (itemSprite != null)
        {
            itemImage.sprite = itemSprite;
        }
        if (itemName != null)
        {
            _itemName.text = itemName;
        }
        if (itemDescription != null)
        {
            _itemDescription.text = itemDescription;
        }        
    }

    public void UpdateInfo(int _itemID)
    {
        itemID = _itemID;
        itemDescription = database.GetDescription[itemID];
        itemName = database.GetName[itemID];
        itemSprite = database.GetSprite[itemID];
    }
}
