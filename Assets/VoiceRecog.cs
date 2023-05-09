using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceRecog : MonoBehaviour
{
    [SerializeField]
    private string[] m_Keywords;

    [SerializeField]
    GameObject _object;

    [SerializeField]
    GameObject mainCamera;

    bool isObjectActive;

    private KeywordRecognizer m_Recognizer;


    // Start is called before the first frame update
    void Start()
    {
        m_Keywords = new string[2];
        m_Keywords[0] = "Notes";
        m_Keywords[1] = "Stop";
       
        m_Recognizer = new KeywordRecognizer(m_Keywords);
        m_Recognizer.OnPhraseRecognized += OnPhraseRecognized;
        m_Recognizer.Start();

        _object.SetActive(false);
        isObjectActive = false;
    }


    private void OnPhraseRecognized(PhraseRecognizedEventArgs args) {
        if (args.text == m_Keywords[0]) {
            Debug.Log("Diag");
            _object.SetActive(!isObjectActive);
            isObjectActive = !isObjectActive;
            if (isObjectActive){
                _object.transform.position = mainCamera.transform.position +
                 mainCamera.transform.forward * 0.7f;
            }
        }
        if (args.text == m_Keywords[1]) {
            Debug.Log("Stop");
            _object.SetActive(false);
        }
    }
}
