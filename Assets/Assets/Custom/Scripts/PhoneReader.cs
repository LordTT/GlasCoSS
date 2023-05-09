using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PhoneReader : MonoBehaviour
{

    List<double> correctnessS;
    List<string> optionsS;
    List<double> correctnessC;
    List<string> optionsC;
    List<double> correctnessA;
    List<string> optionsA;
    List<double> correctnessR;
    List<string> optionsR;
    GameObject hud;
    EvaluationScript evaluator;

    // Start is called before the first frame update
    void Start()
    {
        hud = GameObject.Find("HudCanvas");

        JsonParsing parser = GameObject.Find("ScenarioReader").GetComponent<JsonParsing>();
        S[] s = parser.rootObject.scenario.results.s;

        evaluator = GameObject.Find("Evaluator").GetComponent<EvaluationScript>();

        TMP_Dropdown dropdownS = GameObject.Find("S").GetComponentInChildren<TMP_Dropdown>();

        dropdownS.ClearOptions();

        optionsS = new List<string> { " - " };
        correctnessS = new List<double> { .0 };

        foreach (S d in s)
        {
            optionsS.Add(d.descision);
            correctnessS.Add(d.correctness);
        }

        dropdownS.AddOptions(optionsS);

        dropdownS.onValueChanged.AddListener(delegate {
            DropdownValueChangedS(dropdownS);
        });

        C[] c = parser.rootObject.scenario.results.c;

        TMP_Dropdown dropdownC = GameObject.Find("C").GetComponentInChildren<TMP_Dropdown>();

        dropdownC.ClearOptions();

        optionsC = new List<string> { " - " };
        correctnessC = new List<double> { .0 };

        foreach (C d in c)
        {
            optionsC.Add(d.descision);
            correctnessC.Add(d.correctness);
        }

        dropdownC.AddOptions(optionsC);

        dropdownC.onValueChanged.AddListener(delegate {
            DropdownValueChangedC(dropdownC);
        });

        A[] a = parser.rootObject.scenario.results.a;

        TMP_Dropdown dropdownA = GameObject.Find("A").GetComponentInChildren<TMP_Dropdown>();

        dropdownA.ClearOptions();

        optionsA = new List<string> { " - " };
        correctnessA = new List<double> { .0 };

        foreach (A d in a)
        {
            optionsA.Add(d.descision);
            correctnessA.Add(d.correctness);
        }

        dropdownA.AddOptions(optionsA);

        dropdownA.onValueChanged.AddListener(delegate {
            DropdownValueChangedA(dropdownA);
        });

        R[] r = parser.rootObject.scenario.results.r;

        TMP_Dropdown dropdownR = GameObject.Find("R").GetComponentInChildren<TMP_Dropdown>();

        dropdownR.ClearOptions();

        optionsR = new List<string> { " - " };
        correctnessR = new List<double> { .0 };

        foreach (R d in r)
        {
            optionsR.Add(d.descision);
            correctnessR.Add(d.correctness);
        }

        dropdownR.AddOptions(optionsR);

        dropdownR.onValueChanged.AddListener(delegate {
            DropdownValueChangedR(dropdownR);
        });

        gameObject.SetActive(false);



    }
    void DropdownValueChangedS(TMP_Dropdown change)
    {
        if (correctnessS[change.value] < 0.2 ){
            hud.GetComponent<HudScript>().Notify("Cette decision est grave", 2, Color.red);
        } else if (correctnessS[change.value] < 0.5 ){
            hud.GetComponent<HudScript>().Notify("Cette decision est mauvaise", 2, Color.red);
        } else if (correctnessS[change.value] < 0.8 ){
            hud.GetComponent<HudScript>().Notify("Cette decision est moyenne", 2, Color.yellow);
        } else if (correctnessS[change.value] < 1.0 ){
            hud.GetComponent<HudScript>().Notify("Cette decision est bonne", 2, Color.green);
        } else if (correctnessS[change.value] == 1.0 ){
            hud.GetComponent<HudScript>().Notify("Cette decision est parfaite", 2, Color.green);
        }
        evaluator.playerS = change.value;
    }
    void DropdownValueChangedC(TMP_Dropdown change)
    {
        if (correctnessC[change.value] < 0.2)
        {
            hud.GetComponent<HudScript>().Notify("Cette decision est grave", 2, Color.red);
        }
        else if (correctnessC[change.value] < 0.5)
        {
            hud.GetComponent<HudScript>().Notify("Cette decision est mauvaise", 2, Color.red);
        }
        else if (correctnessC[change.value] < 0.8)
        {
            hud.GetComponent<HudScript>().Notify("Cette decision est moyenne", 2, Color.yellow);
        }
        else if (correctnessC[change.value] < 1.0)
        {
            hud.GetComponent<HudScript>().Notify("Cette decision est bonne", 2, Color.green);
        }
        else if (correctnessC[change.value] == 1.0)
        {
            hud.GetComponent<HudScript>().Notify("Cette decision est parfaite", 2, Color.green);
        }
        evaluator.playerC = change.value;
    }
    void DropdownValueChangedA(TMP_Dropdown change)
    {
        if (correctnessA[change.value] < 0.2)
        {
            hud.GetComponent<HudScript>().Notify("Cette decision est grave", 2, Color.red);
        }
        else if (correctnessA[change.value] < 0.5)
        {
            hud.GetComponent<HudScript>().Notify("Cette decision est mauvaise", 2, Color.red);
        }
        else if (correctnessA[change.value] < 0.8)
        {
            hud.GetComponent<HudScript>().Notify("Cette decision est moyenne", 2, Color.yellow);
        }
        else if (correctnessA[change.value] < 1.0)
        {
            hud.GetComponent<HudScript>().Notify("Cette decision est bonne", 2, Color.green);
        }
        else if (correctnessA[change.value] == 1.0)
        {
            hud.GetComponent<HudScript>().Notify("Cette decision est parfaite", 2, Color.green);
        }
        evaluator.playerA = change.value;
    }
    void DropdownValueChangedR(TMP_Dropdown change)
    {
        if (correctnessR[change.value] < 0.2)
        {
            hud.GetComponent<HudScript>().Notify("Cette decision est grave", 2, Color.red);
        }
        else if (correctnessR[change.value] < 0.5)
        {
            hud.GetComponent<HudScript>().Notify("Cette decision est mauvaise", 2, Color.red);
        }
        else if (correctnessR[change.value] < 0.8)
        {
            hud.GetComponent<HudScript>().Notify("Cette decision est moyenne", 2, Color.yellow);
        }
        else if (correctnessR[change.value] < 1.0)
        {
            hud.GetComponent<HudScript>().Notify("Cette decision est bonne", 2, Color.green);
        }
        else if (correctnessR[change.value] == 1.0)
        {
            hud.GetComponent<HudScript>().Notify("Cette decision est parfaite", 2, Color.green);
        }
        evaluator.playerR = change.value;
    }
}

