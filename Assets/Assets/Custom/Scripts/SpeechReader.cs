using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechReader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    
        JsonParsing parser = GameObject.Find("ScenarioReader").GetComponent<JsonParsing>();
        int value = parser.rootObject.scenario.patient.speech;
        Renderer renderer = GetComponent<Renderer>();
        Color color = Color.black;
        switch (value)
        {
            case 0:
                color = Color.red;
                break;
            case 1:
                color = Color.blue;
                break;
            case 2:
                color = Color.yellow;
                break;
            case 3:
                color = Color.green;
                break;
            default:
                break;
        }

        renderer.material.color = color;

    }
}
