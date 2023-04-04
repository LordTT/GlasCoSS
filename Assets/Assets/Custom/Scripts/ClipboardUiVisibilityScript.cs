using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipboardUiVisibilityScript : MonoBehaviour
{

    private GameObject rig;
    private GameObject ui;
    // Start is called before the first frame update
    void Start()
    {
        rig = GameObject.Find("XR Rig");
        ui = GameObject.Find("CanvasClipboard");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(rig.transform.position, gameObject.transform.position);
        if (distance > 1.5)
        {
            ui.SetActive(false);
        }
        else
        {
            ui.SetActive(true);
        }
    }
}
