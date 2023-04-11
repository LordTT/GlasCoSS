using UnityEngine;
using TMPro;



public class DiagReader : MonoBehaviour
{
    private TMP_Text m_TextComponent;

    public void Start() {

        
        m_TextComponent = GetComponent<TMP_Text>();
        JsonParsing parser = GameObject.Find("ScenarioReader").GetComponent<JsonParsing>();
        Diagnosis[] diags = parser.rootObject.scenario.record.diagnosis;
        string text = "Diagnostiques :\n\n";
        foreach (Diagnosis d in diags) {
            text += d.Date + " :\n\n";
            foreach (string s in d.paragraphs) {
                text += s + "\n\n";
            }
        }
        m_TextComponent.text = text;

    }



}

