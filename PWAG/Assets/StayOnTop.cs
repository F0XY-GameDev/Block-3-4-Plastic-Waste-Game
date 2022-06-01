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
    public Button b;
    public int itemSlot;

    private void Start()
    {
        Button b = gameObject.GetComponent<Button>();
        b.onClick.AddListener(OnClick);
    }
    // Update is called once per frame
    void Update()
    {
        cursor.transform.SetAsLastSibling();
    }
    

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log(this.gameObject.name + " was selected");
        descUI.GetComponent<CursorCollision>().UpdateInfo(playerInventory.Container[itemSlot].ID);
    }

    void OnClick()
    {
        //To Do - add inventory interaction other than reading
        //descUI.GetComponent<CursorCollision>().UpdateInfo(playerInventory.Container[itemSlot].ID);
    }


}
