using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PhoneReader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        JsonParsing parser = GameObject.Find("ScenarioReader").GetComponent<JsonParsing>();
        Descisions[] values = parser.rootObject.scenario.results.descisions;
        TMP_Dropdown dropdown = GetComponentInChildren<TMP_Dropdown>();
        dropdown.ClearOptions();

        if (values.Length == 0)
        {
            gameObject.SetActive(false);
        }

        List<string> options = new List<string> {};

        foreach (Descisions d in values)
        {
            options.Add(d.descision);
        }

        dropdown.AddOptions(options);
    }
}

