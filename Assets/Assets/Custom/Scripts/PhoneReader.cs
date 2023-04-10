using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PhoneReader : MonoBehaviour
{

    List<double> correctness;
    List<string> options;
    GameObject hud;

    // Start is called before the first frame update
    void Start()
    {
        JsonParsing parser = GameObject.Find("ScenarioReader").GetComponent<JsonParsing>();
        Descisions[] values = parser.rootObject.scenario.results.descisions;
        TMP_Dropdown dropdown = GetComponentInChildren<TMP_Dropdown>();
        hud = GameObject.Find("HudCanvas");
        dropdown.ClearOptions();

        if (values.Length == 0)
        {
            gameObject.SetActive(false);
        }

        options = new List<string> {" - "};
        correctness = new List<double> {.0};

        foreach (Descisions d in values)
        {
            options.Add(d.descision);
            correctness.Add(d.correctness);
        }

        dropdown.AddOptions(options);

        dropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(dropdown);
        });

    }
    void DropdownValueChanged(TMP_Dropdown change)
    {
        hud.GetComponent<HudScript>().Notify("This correctness has a value of " + Math.Round(correctness[change.value], 2), 3);
    }
}

