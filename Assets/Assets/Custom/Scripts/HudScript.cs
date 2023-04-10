using System.Collections;
using UnityEngine;
using TMPro;

public class HudScript : MonoBehaviour
{

    TMP_Text m_TextComponent;

    // Start is called before the first frame update
    void Start()
    {
        m_TextComponent = GetComponentInChildren<TMP_Text>();
    }

    public void Notify(string text, int duration) { 
        m_TextComponent.text = text;
        StartCoroutine(NotifyCoroutine(duration));    
    }

    IEnumerator NotifyCoroutine(int duration) {
        yield return new WaitForSeconds(duration);
        m_TextComponent.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
