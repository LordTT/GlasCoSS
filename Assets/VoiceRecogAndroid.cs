using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using System.Collections.Generic;
using System.Linq;

public class VoiceRecogAndroid : MonoBehaviour
{

    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    public Text debugText;

    [SerializeField]
    GameObject _object;

    [SerializeField]
    GameObject mainCamera;

    bool isObjectActive;

    void Start()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }

        keywords.Add("notes", () => {
            Debug.Log("Diag");
            _object.SetActive(!isObjectActive);
            isObjectActive = !isObjectActive;
            if (isObjectActive)
            {
                _object.transform.position = mainCamera.transform.position +
                 mainCamera.transform.forward * 0.7f;
            }
        });

        keywords.Add("stop", () => {
            Debug.Log("Stop");
            _object.SetActive(false);
        });


        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToList().ToArray());

        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;

        keywordRecognizer.Start();
    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;
        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }
}
