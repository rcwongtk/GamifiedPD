using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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
    private string focus;
    private string title;
    private string status;

    //Store Training Entries Here
    public List<TrainingEntryObject> trainingEntryLog = new List<TrainingEntryObject>();
    public List<LevelStatIncreases> allStatIncreases = new List<LevelStatIncreases>();

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

        if (trainingEntryLog.Count > 0)
        {
            // Calculate experience/level based on entries and move slider accordingly
            hours = 0;
            str = 0;
            dex = 0;
            vit = 0;
            intelligence = 0;
            soul = 0;
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
                
                switch(entry.tag)
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
            }
            int tempTotalExp = (int)hours*20;
            int tempLevel = 1 + ((int)tempTotalExp / 100);
            int tempExpRemaining = (int)tempTotalExp % 100;
            level.text = tempLevel.ToString();
            exp.text = "EXP: " + tempExpRemaining.ToString();
            expSlider.value = tempExpRemaining;

            strText.text = ((int)str).ToString();
            dexText.text = ((int)dex).ToString();
            vitText.text = ((int)vit).ToString();
            intText.text = ((int)intelligence).ToString();
            soulText.text = ((int)soul).ToString();


        }




    }
}
