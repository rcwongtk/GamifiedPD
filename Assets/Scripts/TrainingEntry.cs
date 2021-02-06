using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TrainingEntry : MonoBehaviour
{
    public float timeStorage;
    public string typeStorage;
    public string tagStorage;

    // Button parameter passed through when clicked
    public GameObject button;

    // Store current button clicked.
    private GameObject timeButton;
    private GameObject typeButton;
    private GameObject tagButton;

    // If any button is pressed, take the button and depending on the tag store the appropriate information.
    public void buttonExtraction()
    {
        string buttonName = button.name;
        string buttonTag = button.tag;

        // Based on the Tag, take name and place into respective variable:
        switch(buttonTag)
        {
            case "TimeButton":
                // If button is not null, deactivate the image on the button to unhighlight it.
                if(timeButton != null)
                {
                    timeButton.GetComponent<Image>().enabled = false;
                }
                timeButton = button;
                timeButton.GetComponent<Image>().enabled = true;
                timeStorage = float.Parse(buttonName.Substring(0,3));
                break;
            case "TypeButton":
                if (typeButton != null)
                {
                    typeButton.GetComponent<Image>().enabled = false;
                }
                typeButton = button;
                typeButton.GetComponent<Image>().enabled = true;
                typeStorage = buttonName;
                break;
            case "TagButton":
                if (tagButton != null)
                {
                    tagButton.GetComponent<Image>().enabled = false;
                }
                tagButton = button;
                tagButton.GetComponent<Image>().enabled = true;
                tagStorage = buttonName;
                break;

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Store all the training entry buttons in lists, so that once the entry is completed, the buttons can be refreshed.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
