using System.Collections;
using UnityEngine;
using TMPro;

public class HudScript : MonoBehaviour
{

    TMP_Text m_TextComponent;
    GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        m_TextComponent = GetComponentInChildren<TMP_Text>();
        panel = GameObject.Find("HudPanel");
        panel.SetActive(false);
    }

    public void Notify(string text, int duration, Color color) { 
        m_TextComponent.text = text;
        m_TextComponent.color = color;
        panel.SetActive(true);
        StartCoroutine(NotifyCoroutine(duration));    
    }

    IEnumerator NotifyCoroutine(int duration) {
        yield return new WaitForSeconds(duration);
        m_TextComponent.text = "";
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
