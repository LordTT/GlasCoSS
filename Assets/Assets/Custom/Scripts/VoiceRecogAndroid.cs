
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class VoiceRecogAndroid : MonoBehaviour
{

    [SerializeField]
    GameObject _object;

    [SerializeField]
    GameObject mainCamera;

    public Text outputText;
    void Start()
    {
        AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        activity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
        {
            AndroidJavaObject speechRecognizer = new AndroidJavaObject("android.speech.SpeechRecognizer");
            AndroidJavaObject intent = new AndroidJavaObject("android.content.Intent");
            AndroidJavaObject bundle = new AndroidJavaObject("android.os.Bundle");
            bundle.Call("putString", "android.speech.extra.LANGUAGE_MODEL", "free_form");
            bundle.Call("putString", "android.speech.extra.PARTIAL_RESULTS", "true");
            bundle.Call("putString", "android.speech.extra.KEY_PHRASE", "not"); // specify the keyword here
            intent.Call("putExtra", "android.speech.extra.LANGUAGE_MODEL", "free_form");
            intent.Call("putExtra", "android.speech.extra.PARTIAL_RESULTS", "true");
            intent.Call("putExtra", "android.speech.extra.EXTRA_RESULTS_PENDINGINTENT", bundle);
            speechRecognizer.Call("setRecognitionListener", new RecognitionListener(outputText, _object, mainCamera));
            speechRecognizer.Call("startListening", intent);
        }));
    }


    
 

}