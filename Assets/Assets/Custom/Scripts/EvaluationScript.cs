using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvaluationScript : MonoBehaviour
{
    JsonParsing parser;

    public float playerTime;

    public float playerS = 0;
    public float playerC = 0;
    public float playerA = 0;
    public float playerR = 0;

    public int playerEye = 4;
    public int playerSpeech = 5;
    public int playerPhysical = 6;

    public int realEye;
    public int realSpeech;
    public int realPhysical;


    // Start is called before the first frame update
    void Start()
    {
        parser = GameObject.Find("ScenarioReader").GetComponent<JsonParsing>();
        realEye = parser.rootObject.scenario.patient.eye;
        realPhysical = parser.rootObject.scenario.patient.physical;
        realSpeech = parser.rootObject.scenario.patient.speech;
    }

    public void StartTimer()
    {
        playerTime = Time.realtimeSinceStartup;
    }

    public void EndTimer()
    {
        playerTime = Time.realtimeSinceStartup - playerTime;
    }

    // Evaluate the player's performance, and return a score.
    // The s c a and r go between 0 and 1. The higher the better. This score is mildly important.
    // The eye speech and physical should correspond to the real values. This score is really important.
    // The player should take less than 6 minutes to complete the scenario. This score is mildly important.
    // The final score is between 1 and 6
    public float Evaluate () 
    {
        float score = 0;
        float timeScore = 0;
        float sScore = 0;
        float cScore = 0;
        float aScore = 0;
        float rScore = 0;
        float eyeScore = 0;
        float speechScore = 0;
        float physicalScore = 0;

        // Time score
        if (playerTime < 360)
        {
            timeScore = 1;
        }
        else if (playerTime < 420)
        {
            timeScore = 0.8f;
        }
        else if (playerTime < 480)
        {
            timeScore = 0.6f;
        }
        else if (playerTime < 540)
        {
            timeScore = 0.4f;
        }
        else if (playerTime < 600)
        {
            timeScore = 0.2f;
        }
        else
        {
            timeScore = 0;
        }

        // S score
        if (playerS < 0.2f)
        {
            sScore = 1;
        }
        else if (playerS < 0.4f)
        {
            sScore = 0.8f;
        }
        else if (playerS < 0.6f)
        {
            sScore = 0.6f;
        }
        else if (playerS < 0.8f)
        {
            sScore = 0.4f;
        }
        else if (playerS < 1f)
        {
            sScore = 0.2f;
        }
        else
        {
            sScore = 0;
        }

        // C score
        if (playerC < 0.2f)
        {
            cScore = 1;
        }
        else if (playerC < 0.4f)
        {
            cScore = 0.8f;
        }
        else if (playerC < 0.6f)
        {
            cScore = 0.6f;
        }
        else if (playerC < 0.8f)
        {
            cScore = 0.4f;
        }
        else if (playerC < 1f)
        {
            cScore = 0.2f;
        }
        else
        {
            cScore = 0;
        }

        // A score
        if (playerA < 0.2f)
        {
            aScore = 1;
        }
        else if (playerA < 0.4f)
        {
            aScore = 0.8f;
        }
        else if (playerA < 0.6f)
        {
            aScore = 0.6f;
        }
        else if (playerA < 0.8f)
        {
            aScore = 0.4f;
        }
        else if (playerA < 1f)
        {
            aScore = 0.2f;
        }
        else
        {
            aScore = 0;
        }

        // R score
        if (playerR < 0.2f)
        {
            rScore = 1;
        }
        else if (playerR < 0.4f)
        {
            rScore = 0.8f;
        }
        else if (playerR < 0.6f)
        {
            rScore = 0.6f;
        }
        else if (playerR < 0.8f)
        {
            rScore = 0.4f;
        }
        else if (playerR < 1f)
        {
            rScore = 0.2f;
        }
        else
        {
            rScore = 0;
        }

        // Eye score
        if (playerEye == realEye)
        {
            eyeScore = 1;
        }
        else
        {
            eyeScore = 0;
        }

        // Speech score
        if (playerSpeech == realSpeech)
        {
            speechScore = 1;
        }
        else
        {
            speechScore = 0;
        }

        // Physical score
        if (playerPhysical == realPhysical)
        {
            physicalScore = 1;
        }
        else
        {
            physicalScore = 0;
        }

        score = timeScore + sScore + cScore + aScore + rScore + 2*eyeScore + 2*speechScore + 2*physicalScore;

        int maxScore = 11;

        //compound this between 1 and 6

        score = (score / maxScore * 5) + 1;


        return score;
    }
}
