using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
    public GameObject thisButton;
    public GameObject[] objectsToShow;

    
    public void OnPointerEnter(PointerEventData eventData)
    {
        objectsToShow[0].SetActive(true);
        Debug.Log("Pointer Over but with " + eventData);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Pointer Off!");
        objectsToShow[0].SetActive(false);
    }

    public void OnSelect(BaseEventData eventData)
    {
        objectsToShow[0].SetActive(true);
        Debug.Log("Pointer Over 2 but with " + eventData);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        Debug.Log("Pointer Off 2");
        objectsToShow[0].SetActive(false);
    }
}
