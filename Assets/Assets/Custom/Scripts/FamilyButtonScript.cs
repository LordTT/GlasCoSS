using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FamilyButtonScript : MonoBehaviour
{
    private TMP_Text textSelf;
    private TMP_Text textTarget;
    public string question = "question";
    public string answer = "answer";

    // Start is called before the first frame update
    void Start()
    {
        textTarget = GameObject.Find("AnswerText").GetComponent<TMP_Text>();
        textSelf = GetComponentInChildren<TMP_Text>();
        textSelf.text = question;
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    public void TaskOnClick()
    {
        textTarget.text = answer;
    }
}
