using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public MovePlayer movement;
    void OnCollisionEnter(Collision collisionInfo)
   {
       if (collisionInfo.collider.name == "Chaser")
       {
           movement.enabled = false;
       }
   }
}
