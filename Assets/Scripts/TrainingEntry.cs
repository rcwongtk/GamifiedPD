using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TrainingEntry : MonoBehaviour
{
    public LocalPlayer player;
    public GameObject timeScreen;
    public GameObject typeScreen;
    public GameObject tagScreen;
    public GameObject summaryScreen;
    public GameObject characterSummaryScreen;
    public GameObject trainingEntryScreen;

    public float timeStorage;
    public string typeStorage;
    public string tagStorage;

    // Button parameter passed through when clicked
    public GameObject button;

    // Store current button clicked.
    private GameObject timeButton;
    private GameObject typeButton;
    private GameObject tagButton;

    // Summary Values
    public TMP_Text timeSummary;
    public TMP_Text typeSummary;
    public TMP_Text tagSummary;

    // If any button is pressed, take the button and depending on the tag store the appropriate information.
    public void ButtonExtraction()
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
                timeScreen.SetActive(false);
                typeScreen.SetActive(true);
                break;
            case "TypeButton":
                if (typeButton != null)
                {
                    typeButton.GetComponent<Image>().enabled = false;
                }
                typeButton = button;
                typeButton.GetComponent<Image>().enabled = true;
                typeStorage = buttonName;
                typeScreen.SetActive(false);
                tagScreen.SetActive(true);
                break;
            case "TagButton":
                if (tagButton != null)
                {
                    tagButton.GetComponent<Image>().enabled = false;
                }
                tagButton = button;
                tagButton.GetComponent<Image>().enabled = true;
                tagStorage = buttonName;
                tagScreen.SetActive(false);
                summaryScreen.SetActive(true);
                break;

        }
    }

    public void CompleteEntry()
    {
        if(timeStorage == 0 || typeStorage == null || tagStorage == null)
        {
            // Don't continue, change text to say "Please fill all options"
        }
        else
        {
            TrainingEntryObject newEntry = new TrainingEntryObject();
            newEntry.time = timeStorage;
            newEntry.type = typeStorage;
            newEntry.tag = tagStorage;

            // Add to list.
            player.trainingEntryLog.Add(newEntry);

            // Refresh Entry
            timeButton.GetComponent<Image>().enabled = false;
            typeButton.GetComponent<Image>().enabled = false;
            tagButton.GetComponent<Image>().enabled = false;
            timeScreen.SetActive(true);
            typeScreen.SetActive(false);
            tagScreen.SetActive(false);
            summaryScreen.SetActive(false);
            timeStorage = 0;
            typeStorage = null;
            tagStorage = null;
            trainingEntryScreen.SetActive(false);
            characterSummaryScreen.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Update Summary Text
        if(timeButton != null)
        {
            timeSummary.text = timeButton.name;
        }
        if(typeButton != null)
        {
            typeSummary.text = typeStorage;
        }
        if(tagButton != null)
        {
            tagSummary.text = tagStorage;
        }

    }
}
