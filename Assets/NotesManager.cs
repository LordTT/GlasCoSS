using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class NotesManager : MonoBehaviour
{
    [SerializeField]
    GameObject _object;

    [SerializeField]
    GameObject mainCamera;

    bool isObjectActive;

    public InputActionReference toggleReference = null;

    private void Awake()
    {
        toggleReference.action.started += Manage;
    }

    private void OnDestroy()
    {
        toggleReference.action.started -= Manage;
    }

    void Start()
    {
        _object.SetActive(false);
        isObjectActive = false;
    }



    public void Manage(InputAction.CallbackContext context)
    {
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
   
