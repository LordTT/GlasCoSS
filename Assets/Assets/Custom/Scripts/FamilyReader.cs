using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamilyReader : MonoBehaviour
{

    [SerializeField]
    public GameObject prefabButton;

    [SerializeField]
    public GameObject content;

    // Start is called before the first frame update
    void Start()
    {
        JsonParsing parser = GameObject.Find("ScenarioReader").GetComponent<JsonParsing>();
        Discussion[] values = parser.rootObject.scenario.family.discussion;

        if (values.Length == 0) {
            gameObject.SetActive(false);
        }
        

    
        foreach (Discussion d in values) {
            if (d.ID != "default") {
                GameObject button = Instantiate(prefabButton);
                button.GetComponent<FamilyButtonScript>().answer = d.answer;
                button.GetComponent<FamilyButtonScript>().question = d.question;
                button.transform.SetParent(content.transform);
                button.transform.SetLocalPositionAndRotation(new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
                button.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
}
