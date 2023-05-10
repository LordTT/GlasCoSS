
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using KKSpeech;

public class VoiceRecogAndroid : MonoBehaviour
{
    [SerializeField]
    GameObject _object;

    [SerializeField]
    GameObject mainCamera;

    bool isObjectActive;

    void Start()
    {
        SpeechRecognizerListener listener = GameObject.FindObjectOfType<SpeechRecognizerListener>();
        listener.onFinalResults.AddListener(OnFinalResult);
        listener.onPartialResults.AddListener(OnPartialResult);
        SpeechRecognizer.RequestAccess();
        _object.SetActive(true); // TODO
        isObjectActive = true; //TODO
        SpeechRecognizer.StartRecording(true);
    }

    public void OnPartialResult(string result)
    {
        if (result.Contains("notes") || result.Contains("note") || result.Contains("diagnostic") || result.Contains("stop"))
        {
            SpeechRecognizer.StopIfRecording();

            Debug.Log("Diag");
            _object.SetActive(!isObjectActive);
            isObjectActive = !isObjectActive;
            if (isObjectActive)
            {
                _object.transform.position = mainCamera.transform.position +
                 mainCamera.transform.forward * 0.7f;
            }
            SpeechRecognizer.StartRecording(true);
        }
    }

    public void OnFinalResult(string result)
    {
        if (result.Contains("notes") || result.Contains("note") || result.Contains("diagnostic") || result.Contains("stop"))
        {
            SpeechRecognizer.StopIfRecording();

            SpeechRecognizer.StartRecording(true);
        }
    }

}