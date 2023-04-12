using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClipboardReaderScript : MonoBehaviour
{
    GameObject hud;
    int eyeValue;
    int physValue;
    int speechValue;

    // Start is called before the first frame update
    void Start()
    {
        TMP_Dropdown dropdownEye = GameObject.Find("Eye").GetComponentInChildren<TMP_Dropdown>();
        TMP_Dropdown dropdownPhys = GameObject.Find("Physical").GetComponentInChildren<TMP_Dropdown>();
        TMP_Dropdown dropdownSpeech = GameObject.Find("Speech").GetComponentInChildren<TMP_Dropdown>();
        hud = GameObject.Find("HudCanvas");
        JsonParsing parser = GameObject.Find("ScenarioReader").GetComponent<JsonParsing>();

        eyeValue = parser.rootObject.scenario.patient.eye;
        physValue = parser.rootObject.scenario.patient.physical;
        speechValue = parser.rootObject.scenario.patient.speech;

        dropdownEye.onValueChanged.AddListener(delegate
        {
            EyeDropdownValueChanged(dropdownEye);
        });

        dropdownPhys.onValueChanged.AddListener(delegate
        {
            PhysDropdownValueChanged(dropdownPhys);
        });

        dropdownSpeech.onValueChanged.AddListener(delegate
        {
            SpeechDropdownValueChanged(dropdownSpeech);
        });

        gameObject.SetActive(false);

    }
    void EyeDropdownValueChanged(TMP_Dropdown change)
    {
        if (change.value == eyeValue)
        {
            hud.GetComponent<HudScript>().Notify("L'ouverture des yeux a ete correctement diagnosiquee", 2, Color.green);
        }
        else 
        {
            hud.GetComponent<HudScript>().Notify("L'ouverture des yeux n'a pas ete correctement diagnosiquee", 2, Color.red);
        }
    }
    void PhysDropdownValueChanged(TMP_Dropdown change)
    {
        if (change.value == physValue)
        {
            hud.GetComponent<HudScript>().Notify("La reponse moteur a ete correctement diagnosiquee", 2, Color.green);
        }
        else
        {
            hud.GetComponent<HudScript>().Notify("La reponse moteur n'a pas ete correctement diagnosiquee", 2, Color.red);
        }
    }
    void SpeechDropdownValueChanged(TMP_Dropdown change)
    {
        if (change.value == speechValue)
        {
            hud.GetComponent<HudScript>().Notify("La reponse verbale a ete correctement diagnosiquee", 2, Color.green);
        }
        else
        {
            hud.GetComponent<HudScript>().Notify("La reponse verbale n'a pas ete correctement diagnosiquee", 2, Color.red);
        }
    }
}
