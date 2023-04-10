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

    }
    void EyeDropdownValueChanged(TMP_Dropdown change)
    {
        if (change.value == eyeValue)
        {
            hud.GetComponent<HudScript>().Notify("L'ouverture des yeux a �t� correctement diagnosiqu�e", 3);
        }
        else 
        {
            hud.GetComponent<HudScript>().Notify("L'ouverture des yeux n'a pas �t� correctement diagnosiqu�e", 3);
        }
    }
    void PhysDropdownValueChanged(TMP_Dropdown change)
    {
        if (change.value == physValue)
        {
            hud.GetComponent<HudScript>().Notify("La r�ponse moteur a �t� correctement diagnosiqu�e", 3);
        }
        else
        {
            hud.GetComponent<HudScript>().Notify("La r�ponse moteur n'a pas �t� correctement diagnosiqu�e", 3);
        }
    }
    void SpeechDropdownValueChanged(TMP_Dropdown change)
    {
        if (change.value == physValue)
        {
            hud.GetComponent<HudScript>().Notify("La r�ponse verbale a �t� correctement diagnosiqu�e", 3);
        }
        else
        {
            hud.GetComponent<HudScript>().Notify("La r�ponse verbale n'a pas �t� correctement diagnosiqu�e", 3);
        }
    }
}
