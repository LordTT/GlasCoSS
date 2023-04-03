using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamilyReader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        JsonParsing parser = GameObject.Find("ScenarioReader").GetComponent<JsonParsing>();
        Discussion[] values = parser.rootObject.scenario.family.discussion;
        GameObject content = GameObject.Find("content");


        foreach (Discussion d in values) {
            print(d.question);
        }
    }
}
