using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonScript : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("XR Rig");
        Debug.Log("ah");
    }

    public void TaskOnClick()
    {
        player.transform.localPosition = new Vector3(-6, player.transform.localPosition.y, 1);
    }
}
