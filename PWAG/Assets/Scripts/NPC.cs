using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class NPC : MonoBehaviour
{
    [SerializeField]
    private int speechCD;
    public Transform ChatBubble;//UI picture reference
    public Transform NPCharacter; //NPC reference

    private DIalogueSystem dIalogueSystem;//dialogue script reference
    public string Name; //name of the one speaking(if needed)
    [TextArea(5, 10)]
    public string[] sentences; // text for before quest1
    [TextArea(5, 10)]
    public string[] sentences2; // text for during quest1
    [TextArea(5, 10)]
    public string[] sentences3; // text for after quest1 completion
    public bool hasQuest;
    public int questID;

    public GameObject gameStateManager;
   
    void Start()
    {
        dIalogueSystem = FindObjectOfType<DIalogueSystem>(); //assigning the script        
    }

    
    void Update()
    {
        //The Bubble will always pop up above the NPC 
       //ChatBubble.position = Camera.main.WorldToScreenPoint(NPCharacter.position + Vector3.up * 7f);
       Vector3 Pos = Camera.main.WorldToScreenPoint(NPCharacter.position);
       Pos.y += 120;//position above the NPC
       ChatBubble.position = Pos; 
       if (speechCD <= 0)
       {
           speechCD = 0;
       }
       speechCD --;
    }
    
     
    public void OnTriggerStay(Collider other)
    {
        //if the player is within the (capsule collider) range
        this.gameObject.GetComponent<NPC>().enabled = true;
        FindObjectOfType<DIalogueSystem>().EnterRangeOfNPC();        
        if ((other.gameObject.tag == "Player") && Input.GetKeyDown("joystick button 0") && speechCD <=5)
        {
            this.gameObject.GetComponent<NPC>().enabled = true;//activating the NPC script
            dIalogueSystem.Names = Name;
            if (!gameStateManager.GetComponent<GameStateManager>().Q1Flags[0])
            {
                dIalogueSystem.dialogueLines = sentences;
            } else if (gameStateManager.GetComponent<GameStateManager>().Q1Flags[0] && !gameStateManager.GetComponent<GameStateManager>().Q1Flags[2])
            {
                dIalogueSystem.dialogueLines = sentences2;
            } else if (gameStateManager.GetComponent<GameStateManager>().Q1Flags[0] && gameStateManager.GetComponent<GameStateManager>().Q1Flags[2])
            {
                dIalogueSystem.dialogueLines = sentences3;
                gameStateManager.GetComponent<GameStateManager>().Q1Flags[1] = true;
            }
            FindObjectOfType<DIalogueSystem>().NPCName();
            Debug.Log("phase 2 complete");
            speechCD = 60;
            if (hasQuest)
            {
                gameStateManager.GetComponent<GameStateManager>().Q1Flags[0] = true;
            }
        }
    }

    public void OnTriggerExit()
    {
        //if the players inst withing the range- disable the NPC script
        FindObjectOfType<DIalogueSystem>().OutOfRange();
        this.gameObject.GetComponent<NPC>().enabled = false;

    }
}
