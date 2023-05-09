using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaptopInteractionScript : MonoBehaviour
{

    GameObject canvas;
    bool isActive;
    void Start()
    {
        canvas = transform.parent.transform.GetComponentInChildren<Canvas>().gameObject;
        canvas.SetActive(false);
        isActive = false;
     }

    // Update is called once per frame
    public void Interact()
    {
        canvas.SetActive(!isActive);
        isActive = !isActive;
    }
}
