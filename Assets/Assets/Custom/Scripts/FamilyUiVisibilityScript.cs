using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamilyUiVisibilityScript : MonoBehaviour
{

    private GameObject rig;
    private GameObject ui;
    // Start is called before the first frame update
    void Start()
    {
       rig = GameObject.Find("Main Camera");
        ui = GameObject.Find("FamilyCanvas");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(rig.transform.position, gameObject.transform.position + new Vector3(0f, 1.7f, 0f));
        if (distance > 1.5)
        {
            ui.SetActive(false);
        }
        else {
            ui.SetActive(true);
        }
    }
}
