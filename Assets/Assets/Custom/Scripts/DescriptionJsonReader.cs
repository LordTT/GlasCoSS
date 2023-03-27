using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using SimpleJSON;



public class DescriptionJsonReader : MonoBehaviour
{
    private TMP_Text m_TextComponent;

    string encodedString = "{\"method\": \"retrieve_configuration\",\"params\": {\"configuration\" :\"109873839\"}}";

    void Start()
    {
        JSONNode jsonNode = SimpleJSON.JSON.Parse("Assets/Scenarios/SampleScenario.json");

        Debug.Log(jsonNode);

        string action = jsonNode["scenario"]["ID"][0].Value;
        Debug.Log(action);

        m_TextComponent = GetComponent<TMP_Text>();

        m_TextComponent.text = "Some new line of text.";
    }


}
