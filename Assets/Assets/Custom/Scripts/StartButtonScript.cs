using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonScript : MonoBehaviour
{
    GameObject player;
    EvaluationScript evaluator;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("XR Rig");
        evaluator = GameObject.Find("Evaluator").GetComponent<EvaluationScript>();
    }

    public void TaskOnClick()
    {
        player.transform.localPosition = new Vector3(player.transform.localPosition.x + 2, player.transform.localPosition.y, player.transform.localPosition.z);
        evaluator.StartTimer();
    }
}