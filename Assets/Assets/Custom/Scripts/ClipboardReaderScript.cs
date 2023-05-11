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
    int total;
    TMP_Dropdown dropdownEye;
    TMP_Dropdown dropdownPhys;
    TMP_Dropdown dropdownSpeech;
    TMP_Text totalText;
    EvaluationScript evaluator;

    // Start is called before the first frame update
    void Start()
    {
        dropdownEye = GameObject.Find("Eye").GetComponentInChildren<TMP_Dropdown>();
        dropdownPhys = GameObject.Find("Physical").GetComponentInChildren<TMP_Dropdown>();
        dropdownSpeech = GameObject.Find("Speech").GetComponentInChildren<TMP_Dropdown>();
        totalText = GameObject.Find("Total").GetComponentInChildren<TMP_Text>();
        hud = GameObject.Find("HudCanvas");
        JsonParsing parser = GameObject.Find("ScenarioReader").GetComponent<JsonParsing>();

        evaluator = GameObject.Find("Evaluator").GetComponent<EvaluationScript>();

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

        setTotal(totalText, Mathf.Abs(dropdownEye.value - 4 + dropdownSpeech.value - 5 + dropdownPhys.value - 6));

        gameObject.SetActive(false);

    }

    void setTotal(TMP_Text text, int total) {
        text.text = "Total : " + total;
    }
    void EyeDropdownValueChanged(TMP_Dropdown change)
    {
        if (Mathf.Abs(change.value - 4) == eyeValue)
        {
            hud.GetComponent<HudScript>().Notify("L'ouverture des yeux a ete correctement diagnostiquee", 2, Color.green);
        }
        else 
        {
            hud.GetComponent<HudScript>().Notify("L'ouverture des yeux n'a pas ete correctement diagnostiquee", 2, Color.red);
        }

        setTotal(totalText, Mathf.Abs(dropdownEye.value - 4 + dropdownSpeech.value - 5 + dropdownPhys.value - 6));
        evaluator.playerEye = Mathf.Abs(change.value - 4);

    }
    void PhysDropdownValueChanged(TMP_Dropdown change)
    {
        if (Mathf.Abs(change.value - 6) == physValue)
        {
            hud.GetComponent<HudScript>().Notify("La reponse moteur a ete correctement diagnostiquee", 2, Color.green);
        }
        else
        {
            hud.GetComponent<HudScript>().Notify("La reponse moteur n'a pas ete correctement diagnostiquee", 2, Color.red);
        }

        setTotal(totalText, Mathf.Abs(dropdownEye.value - 4 + dropdownSpeech.value - 5 + dropdownPhys.value - 6));
        evaluator.playerPhysical = Mathf.Abs(change.value - 6);
    }
    void SpeechDropdownValueChanged(TMP_Dropdown change)
    {
        if (Mathf.Abs(change.value - 5) == speechValue)
        {
            hud.GetComponent<HudScript>().Notify("La reponse verbale a ete correctement diagnostiquee", 2, Color.green);
        }
        else
        {
            hud.GetComponent<HudScript>().Notify("La reponse verbale n'a pas ete correctement diagnostiquee", 2, Color.red);
        }

        setTotal(totalText, Mathf.Abs(dropdownEye.value - 4 + dropdownSpeech.value - 5 + dropdownPhys.value - 6));
        evaluator.playerSpeech = Mathf.Abs(change.value - 5);
    }
}
