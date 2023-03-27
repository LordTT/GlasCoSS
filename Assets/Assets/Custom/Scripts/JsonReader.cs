using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class JsonReader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var scenario = JSON.Parse("Scenarios/SampleScenario.json");
        foreach (JSONNode scene in scenario)
        {
            foreach (JSONNode item in scene)
            {
                string type = item["type"];
                if (type == "patient")
                {
                    foreach (JSONNode symptoms in item) 
                    {
                        type = symptoms["type"];
                        if (type == "symptoms")
                        {
                            foreach (JSONNode part in symptoms)
                            {
                                type = part["type"];
                                if (type == "eye") 
                                {
                                    Debug.Log(type + " " + part);
                                }
                            }
                        }
                    }
                }
                else if (type == "slider")
                {
                    
                }
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
 
// [ ... ]
 
}
