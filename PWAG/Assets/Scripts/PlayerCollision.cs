using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameObject checkpointBox;
    Vector3 spawnPoint;
    public characterMovement movement;
    public static Vector3 checkpointPos;
    
    void Start()
    {
        spawnPoint = gameObject.transform.position;
    }
    void OnCollisionEnter(Collision collisionInfo)
   {
       if (collisionInfo.collider.name == "Guard")
       {
           movement.enabled = false;
           PlayerManager.gameOver = true;//game over screen
           gameObject.transform.position = spawnPoint;
           GameObject.FindGameObjectWithTag("Player").transform.position=checkpointPos;
       }
   }
   private void OnTriggerEnter(Collider other)
   {
    if(other.gameObject.CompareTag("Checkpoint"))
    {
        spawnPoint = checkpointBox.transform.position;
    }
   }
}
