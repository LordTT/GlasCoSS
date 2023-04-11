using UnityEngine;
using TMPro;



public class DescReader : MonoBehaviour
{
    private TMP_Text m_TextComponent;

    public void Start() {

        
        m_TextComponent = GetComponent<TMP_Text>();
        JsonParsing parser = GameObject.Find("ScenarioReader").GetComponent<JsonParsing>();
        string text = parser.rootObject.scenario.record.history.ToString();
        m_TextComponent.text = "Decription :\n\n" + text;

    }



}

