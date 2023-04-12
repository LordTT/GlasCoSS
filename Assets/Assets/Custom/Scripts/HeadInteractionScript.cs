using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadInteractionScript : MonoBehaviour
{

    GameObject hud;
    int value;
    void Start()
    {
        hud = GameObject.Find("HudCanvas");
        JsonParsing parser = GameObject.Find("ScenarioReader").GetComponent<JsonParsing>();
        value = parser.rootObject.scenario.patient.eye;
     }

    // Update is called once per frame
    public void Interact()
    {
        hud.GetComponent<HudScript>().Notify("Interaction yeux : " + value , 2, Color.green);

    }
}
