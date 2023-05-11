using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiFollowPlayerScript : MonoBehaviour
{
    [SerializeField] GameObject _object;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - _object.transform.position);
        transform.position = Camera.main.transform.position + Camera.main.transform.forward * 0.5f - Camera.main.transform.up * 0.1f;
    }
}
