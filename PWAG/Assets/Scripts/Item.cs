using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemObject item; //this tells us that a gameobject is an item, and not an NPC, terrain, or decoration
    public bool hasFlag; //this tells us if the gameobject has a progression Flag attached;
    //public int amount;
}
