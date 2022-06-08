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
    public void OnControllerColliderHit(Collider2D other)  //when cursor collides with other
    {
        g = other.transform.parent.gameObject; //g copies all values of the other gameobject
        itemID = g.GetComponent<ItemID>().ID; //get itemID of g
        Debug.Log("trigger"); //idk I needed this at some point
    }

    // Update is called once per frame
    void Update()
    {
        if (itemSprite != null) //if we have set itemSprite
        {
            itemImage.sprite = itemSprite; //invdescription image is set to itemSprite
        }
        if (itemName != null) //if we have set itemName
        {
            _itemName.text = itemName; //invdescription name field is set to itemName
        }
        if (itemDescription != null) // if we have set itemDescription
        {
            _itemDescription.text = itemDescription; //invdescription text is set to itemDescription
        }
    }

    public void UpdateInfo(int _itemID) //to update the info of the invdescription we need to be given an itemID from which we can gather the description, name, and sprite of the object
    {
        itemID = _itemID; //changing the variable set as the parameter can cause issues
        itemDescription = database.GetDescription[itemID]; //get itemDescription from dictionary
        itemName = database.GetName[itemID]; //get itemName from dictionary
        itemSprite = database.GetSprite[itemID]; //get itemSprite from dictionary
    }
}
