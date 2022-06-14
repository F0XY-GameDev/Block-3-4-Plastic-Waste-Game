using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public characterMovement movement;
    void OnCollisionEnter(Collision collisionInfo)
   {
       if (collisionInfo.collider.name == "Guard")
       {
           movement.enabled = false;
           PlayerManager.gameOver = true;//game over screen
           
       }
   }
}
