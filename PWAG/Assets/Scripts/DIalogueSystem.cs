using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class DIalogueSystem : MonoBehaviour
{
    public GameObject player;
    private PlayerControlls playerControlls;
    private PlayerInput playerInput;

    public Text nameText;
    public Text dialogueText;

    public GameObject dialogueUI;//pop up "F to chat"
    public Transform dialogueBoxUi;

    public float letterDelay = 0.1f; //delaing the text
    public float letterMultiplier = 0.5f;//letter multiplier(hold to speed the text)

    public string Names;
    public string[] dialogueLines;

    public bool letterMultiplied = false;
    public bool dialogueActive = false;
    public bool dialogueEnded = false;
    public bool outOfRange = true;

    public GameObject NPC;
    public GameObject gameStateManager;

    private void Awake()
    {
        playerControlls = player.GetComponent<characterMovement>().input;
        playerInput = GetComponent<PlayerInput>();
    }

    void Start()
    {
        dialogueText.text = "";
    }

    
    void Update()
    {
        
    }

    public void EnterRangeOfNPC()
    {
        outOfRange = false;
        dialogueUI.SetActive(true);
        if(dialogueActive == true)
            {
                dialogueUI.SetActive(false);
            }
    }

    public void NPCName()
    {
        outOfRange = false;
        dialogueBoxUi.gameObject.SetActive(true);
        nameText.text = Names;
        if(Input.GetKeyDown("joystick button 0"))
            {
                if(!dialogueActive)
                    {
                        dialogueActive = true;
                        StartCoroutine(StartDialogue());
                    }
            }
        StartDialogue();
    }

    private IEnumerator StartDialogue()
    {
        if(outOfRange == false)
            {
                int dialogueLength = dialogueLines.Length;
                int currentDialogueIndex = 0;

                while (currentDialogueIndex < dialogueLength || !letterMultiplied)
                {
                    if(!letterMultiplied)
                    {
                        letterMultiplied = true;
                        StartCoroutine(DisplayString(dialogueLines[currentDialogueIndex++]));

                        if(currentDialogueIndex >= dialogueLength)
                        {
                            dialogueEnded = true;
                        }
                    }
                    yield return 0;
                }
                while (true)
                {
                    if(Input.GetKey("joystick button 0") && dialogueEnded == false)
                    {
                        break;
                    }
                    yield return 0;
                }
                dialogueEnded = false;
                dialogueActive = false;
                DropDialogue();
            }
    }

    private IEnumerator DisplayString(string stringToDisplay)
    {
        if(outOfRange == false)
        {
            int stringLenght = stringToDisplay.Length;
            int currentCharacterIndex = 0;

            dialogueText.text = "";

            while(currentCharacterIndex < stringLenght)
            {
                dialogueText.text += stringToDisplay[currentCharacterIndex];
                currentCharacterIndex++;

                if(currentCharacterIndex < stringLenght)
                {
                    if (Input.GetKey("joystick button 1"))
                    {
                        yield return new WaitForSeconds(letterDelay * letterMultiplier);

                    }
                    else
                    {
                        yield return new WaitForSeconds(letterDelay);
                    }

                }
                else
                {
                    dialogueEnded = false;
                    break;
                }
            }
            while(true)
            {
                if (Input.GetKey("joystick button 0"))
                {
                    break;
                }
                yield return 0;
            }
            dialogueEnded = false;
            letterMultiplied = false;
            dialogueText.text = "";

        }
    }

    public void DropDialogue()
    {        
        dialogueUI.SetActive(false);
        dialogueBoxUi.gameObject.SetActive(false);
    }

    public void OutOfRange()
    {
        outOfRange = true;
        if(outOfRange == true)
        {
            letterMultiplied = false;
            dialogueActive = false;
            StopAllCoroutines();
            dialogueUI.SetActive(false);
            dialogueBoxUi.gameObject.SetActive(false);
        }
    }
}
