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

        gameObject.SetActive(false);

    }
    void DropdownValueChanged(TMP_Dropdown change)
    {
        if (correctness[change.value] < 0.2 ){
            hud.GetComponent<HudScript>().Notify("Cette decision est grave", 2, Color.red);
        } else if (correctness[change.value] < 0.5 ){
            hud.GetComponent<HudScript>().Notify("Cette decision est mauvaise", 2, Color.red);
        } else if (correctness[change.value] < 0.8 ){
            hud.GetComponent<HudScript>().Notify("Cette decision est moyenne", 2, Color.yellow);
        } else if (correctness[change.value] < 1.0 ){
            hud.GetComponent<HudScript>().Notify("Cette decision est bonne", 2, Color.green);
        } else if (correctness[change.value] == 1.0 ){
            hud.GetComponent<HudScript>().Notify("Cette decision est parfaite", 2, Color.green);
        }
    }
}

