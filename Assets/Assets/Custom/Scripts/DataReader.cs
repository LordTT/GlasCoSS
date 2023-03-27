using UnityEngine;
using TMPro;



public class DataReader : MonoBehaviour
{
    private TMP_Text m_TextComponent;

    public void Start() {

        
        m_TextComponent = GetComponent<TMP_Text>();
        JsonParsing parser = GameObject.Find("ScenarioReader").GetComponent<JsonParsing>();
        string size = parser.rootObject.scenario.record.size;
        string weight = parser.rootObject.scenario.record.weight;
        string bmi = parser.rootObject.scenario.record.bmi;
        m_TextComponent.text = "Taille : " + size + "\nPoids : " + weight + "\nBMI : " + bmi;
    }



}

