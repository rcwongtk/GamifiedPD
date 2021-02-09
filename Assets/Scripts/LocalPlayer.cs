using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using System;

public class LocalPlayer : MonoBehaviour
{
    // Player Stats Here
    public TMP_Text level;
    public TMP_Text exp;
    public Slider expSlider;

    private int hp;
    private int mp;
    public TMP_Text strText;
    public TMP_Text dexText;
    public TMP_Text vitText;
    public TMP_Text intText;
    public TMP_Text soulText;

    // Player Details here
    private string crew;
    public TMP_Text focus;
    private string title;
    public TMP_Text status;

    private List<string> tags = new List<string>();

    //Store Training Entries Here
    public List<TrainingEntryObject> trainingEntryLog = new List<TrainingEntryObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(trainingEntryLog.Count);

        float hours;
        float str;
        float dex;
        float vit;
        float intelligence;
        float soul;

        if(trainingEntryLog.Count > 0)
        {
            // Calculate experience/level based on entries and move slider accordingly
            hours = 0;
            str = 0;
            dex = 0;
            vit = 0;
            intelligence = 0;
            soul = 0;
            tags.Clear();

            foreach(TrainingEntryObject entry in trainingEntryLog)
            {
                hours += entry.time;

                // for each of the tags in the stat, we are going to sort them out and ratio them.
                // Social - None
                // Experimentation - int
                // Battle - soul
                // Toprock - dex / vit
                // Footwork - dex / vit
                // Power - str / vit
                // Freezes - str / dex
                // Freestyle - soul
                // Sets / Runs - vit
                // Cardio - vit
                // Strength - str

                // Keep Simple for now, 1 hr = 1 stat up for tag.
                switch(entry.type)
                {
                    case "Social":
                        break;
                    case "Experimentation":
                        intelligence += entry.time;
                        break;
                    case "Battle":
                        soul += entry.time;
                        break;
                }
                
                switch(entry.entryTag)
                {
                    case "Toprock":
                        dex += entry.time;
                        vit += entry.time;
                        break;
                    case "Footwork":
                        dex += entry.time;
                        vit += entry.time;
                        break;
                    case "Power":
                        str += entry.time;
                        vit += entry.time;
                        break;
                    case "Freezes":
                        str += entry.time;
                        dex += entry.time;
                        break;
                    case "Freestyle":
                        soul += entry.time;
                        break;
                    case "Sets / Runs":
                        vit += entry.time;
                        break;
                    case "Cardio":
                        vit += entry.time;
                        break;
                    case "Strength":
                        str += entry.time;
                        break;
                    default:
                        Debug.Log("Error - Tag not correct look into it");
                        break;

                }

                tags.Add(entry.entryTag);

            }
            int tempTotalExp = (int)(hours*20);
            int tempLevel = 1 + ((int)(tempTotalExp / 100));
            int tempExpRemaining = (int)(tempTotalExp % 100);
            level.text = tempLevel.ToString();
            exp.text = "EXP: " + tempExpRemaining.ToString();
            expSlider.value = tempExpRemaining;

            strText.text = ((int)str).ToString();
            dexText.text = ((int)dex).ToString();
            vitText.text = ((int)vit).ToString();
            intText.text = ((int)intelligence).ToString();
            soulText.text = ((int)soul).ToString();

            List<List<string>> slottedList = new List<List<string>>();

            foreach(string tag in tags)
            {
                bool listExists = false;

                for(int i = 0; i < slottedList.Count; i++)
                {
                    if(slottedList[i].Contains(tag))
                    {
                        slottedList[i].Add(tag);
                        listExists = true;
                    }
                }

                if(listExists == false)
                {
                    slottedList.Add(new List<string>());
                    slottedList[slottedList.Count - 1].Add(tag);
                }
            }

            int listCount = 0;
            string listTag = "-";
            foreach(List<string> list in slottedList)
            {
                if(list.Count > listCount)
                {
                    listCount = list.Count;
                    listTag = list[0];
                }
            }

            focus.text = listTag;

        }

        if(trainingEntryLog.Count >= 2)
        {
            // Compare the last two entries. If the time between the two is greater than 1 week, flag as "Lacking Training"
            // If the time between the two is greater than 3 days, flag as "Training Less"
            // If the time between the two is less than 3 days, flag as "Rocking Hard"
            DateTime time1 = DateTime.Parse(trainingEntryLog[trainingEntryLog.Count - 1].timeCreated);
            DateTime time2 = DateTime.Now;

            TimeSpan trainingDifference = time2 - time1;

            if(trainingDifference.Days > 7)
            {
                status.text = "Lacking Training";
            }
            else if(trainingDifference.Days > 3 && trainingDifference.Days < 7)
            {
                status.text = "Losing Motivation";
            }
            else if(trainingDifference.Days <= 3)
            {
                status.text = "Rocking Hard";
            }

        }


    }
}
