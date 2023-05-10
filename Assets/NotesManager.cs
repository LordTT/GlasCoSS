using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesManager : MonoBehaviour
{
    [SerializeField]
    GameObject _object;

    [SerializeField]
    GameObject mainCamera;

    bool isObjectActive;

    void Start()
    {
        _object.SetActive(false); // TODO
        isObjectActive = false; //TODO
    }

    public void Manage() {
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