using UnityEngine;
using UnityEngine.Android;
using System.Collections.Generic;

public class VoiceRecogAndroid: MonoBehaviour
{

    [SerializeField]
    GameObject _object;

    [SerializeField]
    GameObject mainCamera;

    bool isObjectActive;

    private const string ANDROID_PERMISSION_RECORD_AUDIO = "android.permission.RECORD_AUDIO";
    private AndroidJavaObject speechRecognizer;

    private Dictionary<string, System.Action> actions = new Dictionary<string, System.Action>();

    void Start()
    {
        if (!Permission.HasUserAuthorizedPermission(ANDROID_PERMISSION_RECORD_AUDIO))
        {
            Permission.RequestUserPermission(ANDROID_PERMISSION_RECORD_AUDIO);
        }

        actions.Add("notes", Notes);
        actions.Add("stop", Stop);

        AndroidJavaObject context = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        speechRecognizer = new AndroidJavaObject("android.speech.RecognitionListener");
        speechRecognizer.Call("setRecognitionListener", new SpeechRecognizerListener(this));
        speechRecognizer.Call("startListening", null);
    }

    private class SpeechRecognizerListener : AndroidJavaProxy
    {
        private VoiceRecogAndroid recognizer;

        public SpeechRecognizerListener(VoiceRecogAndroid recognizer) : base("android.speech.RecognitionListener")
        {
            this.recognizer = recognizer;
        }

        void onReadyForSpeech(AndroidJavaObject args)
        {
            Debug.Log("Speech recognizer is now ready for speech");
        }

        void onBeginningOfSpeech(AndroidJavaObject args)
        {
            Debug.Log("Speech recognition has begun");
        }

        void onEndOfSpeech(AndroidJavaObject args)
        {
            Debug.Log("Speech recognition has ended");
        }

        void onError(AndroidJavaObject args)
        {
            Debug.Log("Speech recognition error: " + args.Call<int>("getError"));
            recognizer.speechRecognizer.Call("startListening", null);
        }

        void onResults(AndroidJavaObject args)
        {
            List<string> results = new List<string>();
            AndroidJavaObject javaResults = args.Call<AndroidJavaObject>("getStringArrayList", "results_recognition");
            for (int i = 0; i < javaResults.Call<int>("size"); i++)
            {
                results.Add(javaResults.Call<string>("get", i));
            }

            string result = results[0].ToLowerInvariant();
            Debug.Log("Recognized phrase: " + result);

            System.Action keywordAction;
            if (recognizer.actions.TryGetValue(result, out keywordAction))
            {
                keywordAction.Invoke();
            }

            recognizer.speechRecognizer.Call("startListening", null);
        }
    }

    private void Notes()
    {
        Debug.Log("Diag");
        _object.SetActive(!isObjectActive);
        isObjectActive = !isObjectActive;
        if (isObjectActive)
        {
            _object.transform.position = mainCamera.transform.position +
             mainCamera.transform.forward * 0.7f;
        }
    }

    private void Stop()
    {
        Debug.Log("Stop");
        _object.SetActive(false);
    }
}