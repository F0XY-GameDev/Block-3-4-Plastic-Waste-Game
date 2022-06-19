using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JournalSystem : MonoBehaviour
{

    public GameObject journalSystem;
    public GameObject notificationSystem;
    [TextArea(5, 10)] public string[] questNames; //list of all quest Names
    [TextArea(5, 10)] public string[] questDescriptions; //list of all quest Descriptions 
    [TextArea(5, 10)] public string[] quest1Requirements; //list of all quest1 requirements
    [TextArea(5, 10)] public int[] quest1RequirementsInts; //to track numbered requirements
    [TextArea(5, 10)] public bool[] quest1RequirementsBools; //to track boolean requirements

    public int currentQuest; //for use if game receives more quests
    public GameObject ST1; //gameobjects for the strikethrough of the objectives
    public GameObject ST2;
    public GameObject ST3;
    public GameObject gameStateManager; //references our queststate
    //Below TMPUGUI are direct references to the text in our journal, makes it easier to adjust text + properties
    public TextMeshProUGUI GOQuestName;
    public TextMeshProUGUI GOQuestDescription;
    public TextMeshProUGUI GOQuestRequirement1;
    public TextMeshProUGUI GOQuestRequirement2;
    public TextMeshProUGUI GOQuestRequirement3;

    void Start()
    {
        ST1.SetActive(false); //hide strikethroughs
        ST2.SetActive(false);
        ST3.SetActive(false);
        GOQuestName.text = questNames[0]; //set default quest name
        GOQuestDescription.text = questDescriptions[1]; //set quest description
        GOQuestRequirement1.text = "- " + quest1Requirements[0]; //set requirements
        GOQuestRequirement2.text = "- " + quest1Requirements[1];
        GOQuestRequirement3.text = "- " + quest1Requirements[2];
        GOQuestRequirement1.alpha = 1f; //show first objective, hide others
        GOQuestRequirement2.alpha = 0f;
        GOQuestRequirement3.alpha = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText(gameStateManager.GetComponent<GameStateManager>().Q1Flags[0], gameStateManager.GetComponent<GameStateManager>().Q1Flags[1], gameStateManager.GetComponent<GameStateManager>().Q1Flags[2]); //run UpdateText() with quest flag parameters as passthrough values
    }

    void UpdateText(bool hasAcceptedQ1, bool hasCompletedQ1, bool hasCompletedQ1Obj) //gets passed quest state values
    {
        if (hasCompletedQ1)
        {            
            GOQuestName.text = questNames[0];
            GOQuestDescription.text = questDescriptions[4];
            GOQuestRequirement1.alpha = 1f;
            GOQuestRequirement2.alpha = 1f;
            GOQuestRequirement3.alpha = 1f;
            ST1.SetActive(true);
            ST2.SetActive(true);
            ST3.SetActive(true);
            return; //if we've finished Q1, we ignore other code
        }

        if (hasCompletedQ1Obj)
        {
            ST2.SetActive(true);
            GOQuestRequirement3.alpha = 1f;
            GOQuestDescription.text = questDescriptions[3];
            return; //if we've completed Q1Obj, ignore other code
        }

        if (hasAcceptedQ1)
        {            
            ST1.SetActive(true);
            GOQuestRequirement2.alpha = 1f;
            GOQuestDescription.text = questDescriptions[2];
        }
    }
}
