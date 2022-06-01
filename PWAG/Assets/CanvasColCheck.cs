using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasColCheck : MonoBehaviour
{
    //the object with this script will check for collisions between the cursor and the inventory slots
    //it will then call the script in the cursor that opens the description of the inventory slot, for which
    //this script will pass through the values of the invSlot we are colliding with 
    //this will also only happen if the invSlot has an item at all.
    public GameObject cursor;
}
