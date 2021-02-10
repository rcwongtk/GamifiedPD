using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementUnlocker : MonoBehaviour
{
    public LocalPlayer localPlayer;
    public GameObject achievementParent;
    private List<GameObject> achievementObjects = new List<GameObject>();

    bool musicalityActivated = false;
    bool flyingActivated = false;

    // Start is called before the first frame update
    void Start()
    {
        // Takes each of the achievements, and stores them into a list;
        foreach(Transform achievement in achievementParent.transform)
        {
            achievementObjects.Add(achievement.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Constantly check local player for the following achievements:
        // Musicality
        if(int.Parse(localPlayer.soulText.text) > 5 && musicalityActivated == false)
        {
            foreach (GameObject go in achievementObjects)
            {
                if (go.name == "Musicality")
                {
                    go.SetActive(true);
                    musicalityActivated = true;
                }
            }
        }
        // Flying
        if (int.Parse(localPlayer.strText.text) > 5 && flyingActivated == false)
        {
            foreach (GameObject go in achievementObjects)
            {
                if (go.name == "Flying")
                {
                    go.SetActive(true);
                    flyingActivated = true;
                }
            }
        }
    }
}
