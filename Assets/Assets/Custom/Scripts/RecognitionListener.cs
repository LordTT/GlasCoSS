using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class RecognitionListener : AndroidJavaProxy
{
    [SerializeField]
    GameObject _object;

    [SerializeField]
    GameObject mainCamera;

    bool isObjectActive;

    private Text outputText;
    private bool isKeywordDetected = false;

    public RecognitionListener(Text outputText, GameObject thing, GameObject camera) : base("android.speech.RecognitionListener")
    {
        this.outputText = outputText;
        this._object = thing;
        this.mainCamera = camera;
        _object.SetActive(false);
        isObjectActive = false;
    }

    public void onPartialResults(AndroidJavaObject results)
    {
        AndroidJavaObject matches = results.Call<AndroidJavaObject>("getStringArrayList", "RESULTS_RECOGNITION");
        string[] strings = AndroidJNIHelper.ConvertFromJNIArray<string[]>(matches.GetRawObject());

        if (strings.Length > 0)
        {
            if (strings[0].ToLower().Contains("not"))
            {
                isKeywordDetected = true;
                Debug.Log("Diag");
                _object.SetActive(!isObjectActive);
                isObjectActive = !isObjectActive;
                if (isObjectActive)
                {
                    _object.transform.position = mainCamera.transform.position +
                        mainCamera.transform.forward * 0.7f;
                }

            }
        }
    }

    public void onResults(AndroidJavaObject results)
    {
        if (isKeywordDetected)
        {
            AndroidJavaObject matches = results.Call<AndroidJavaObject>("getStringArrayList", "RESULTS_RECOGNITION");
            string[] strings = AndroidJNIHelper.ConvertFromJNIArray<string[]>(matches.GetRawObject());

            if (strings.Length > 0)
            {
                outputText.text = strings[0];
            }

            isKeywordDetected = false;
        }
    }
}