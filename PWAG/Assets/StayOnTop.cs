using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StayOnTop : MonoBehaviour , IPointerEnterHandler
{
    public GameObject cursor;
    public InventoryObject playerInventory;
    public GameObject descUI;
    public GameObject inventoryOptions;
    public Button b;
    public Transform itemSlotPos;
    public int itemSlot;

    private void Start()
    {
        Button b = gameObject.GetComponent<Button>();
        b.onClick.AddListener(OnClick);
    }

    
    void Update()
    {
        //cursor.transform.SetAsLastSibling();
    }
    

    public void OnPointerEnter(PointerEventData eventData) //when pointer collides with other UI object
    {
        Debug.Log(this.gameObject.name + " was selected"); //log in console what object is selected
        itemSlotPos = this.gameObject.transform; //set itemSlotPos to be passed on to other methods
        descUI.GetComponent<CursorCollision>().UpdateInfo(playerInventory.Container[itemSlot].ID); //Pass values of slot selected to script displaying item descriptions
    }

    void OnClick()
    {
        /*To Do - add inventory interaction other than reading
        inventoryOptions.SetActive(true); //Display our Inventory options menu (that does not yet exist)
        inventoryOptions.GetComponent<InventoryOptions>().SetPosition(itemSlotPos);//passthrough itemSlot transform location to Inventory options script
        */
    }


}
