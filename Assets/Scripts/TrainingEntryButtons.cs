using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainingEntryButtons : MonoBehaviour
{

    public GameObject trainingEntry;


    // Start is called before the first frame update
    void Start()
    {
        trainingEntry = GameObject.Find("Main Camera");
        gameObject.GetComponent<Button>().onClick.AddListener(() => CallButtonExtraction());
    }

    public void CallButtonExtraction()
    {
        trainingEntry.GetComponent<TrainingEntry>().button = gameObject;
        trainingEntry.GetComponent<TrainingEntry>().buttonExtraction();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
