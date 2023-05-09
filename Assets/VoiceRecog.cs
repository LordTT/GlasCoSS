using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceRecog : MonoBehaviour
{
    [SerializeField]
    private string[] m_Keywords;

    private KeywordRecognizer m_Recognizer;


    // Start is called before the first frame update
    void Start()
    {
        m_Keywords = new string[1];
        m_Keywords[0] = "Diagnostic";
        m_Recognizer = new KeywordRecognizer(m_Keywords);
        m_Recognizer.OnPhraseRecognized += OnPhraseRecognized;
        m_Recognizer.Start();

    }


    private void OnPhraseRecognized(PhraseRecognizedEventArgs args) {
        Debug.Log("voice");
        if (args.text == m_Keywords[0]) {
            Debug.Log("diagnostic");
        }
    }
}
