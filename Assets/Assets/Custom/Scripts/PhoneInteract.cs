using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PhoneInteract : MonoBehaviour
{

    [SerializeField]
    GameObject canevas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact(SelectEnterEventArgs args) {
        if (args.interactorObject.transform.name != "Socket") {
            canevas.SetActive(true);
        }
    
    }
}
