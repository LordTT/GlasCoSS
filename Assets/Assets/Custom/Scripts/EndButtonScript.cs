using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndButtonScript : MonoBehaviour
{
    EvaluationScript evaluator;
    TMP_Text glasgow;
    TMP_Text scar;
    TMP_Text final;
    GameObject canvas;
    [SerializeField]
    AudioSource audio;
    GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        evaluator = GameObject.Find("Evaluator").GetComponent<EvaluationScript>();
        glasgow = GameObject.Find("glasgow").GetComponentInChildren<TMP_Text>();
        scar = GameObject.Find("scar").GetComponentInChildren<TMP_Text>();
        final = GameObject.Find("final").GetComponentInChildren<TMP_Text>();


        canvas = GameObject.Find("CanvasSummary");
        player = GameObject.Find("XR Rig");


        canvas.SetActive(false);
    }

    public void TaskOnClick()
    {
        canvas.SetActive(true);

        audio.Stop();

        evaluator.EndTimer();
        float finalScore = evaluator.Evaluate();

        player.transform.localPosition = new Vector3(player.transform.localPosition.x - 6, player.transform.localPosition.y, player.transform.localPosition.z - 2);

        //list in galsgow the glasgow scores agaist the real ones and the time in french wiht /n/n
        glasgow.text = "Yeux vous:" + evaluator.playerEye + " / réel:" + evaluator.realEye + "\n\nParole vous:" + evaluator.playerSpeech + " / réel:" + evaluator.realSpeech + "\n\nCorps vous:" + evaluator.playerPhysical + " / réel:" + evaluator.realPhysical + "\n\n" + "Temps: " + evaluator.playerTime.ToString("F2") + "s";
        //list in scar the s c a and r scores
        if(evaluator.playerS < 0.2){
            scar.text = "S : Cette decision est grave";
        } else if (evaluator.playerS < 0.4){
            scar.text = "S : Cette decision est mauvaise";
        } else if (evaluator.playerS < 0.6){
            scar.text = "S : Cette decision est moyenne";
        } else if (evaluator.playerS < 0.8){
            scar.text = "S : Cette decision est bonne";
        } else {
            scar.text = "S : Cette decision est parfaite";
        }

        if(evaluator.playerC < 0.2){
            scar.text = scar.text + "\n\n" + "C : Cette decision est grave";
        } else if (evaluator.playerC < 0.4){
            scar.text = scar.text + "\n\n" + "C : Cette decision est mauvaise";
        } else if (evaluator.playerC < 0.6){
            scar.text = scar.text + "\n\n" + "C : Cette decision est moyenne";
        } else if (evaluator.playerC < 0.8){
            scar.text = scar.text + "\n\n" + "C : Cette decision est bonne";
        } else {
            scar.text = scar.text + "\n\n" + "C : Cette decision est parfaite";
        }

        if(evaluator.playerA < 0.2){
            scar.text = scar.text + "\n\n" + "A : Cette decision est grave";
        } else if (evaluator.playerA < 0.4){
            scar.text = scar.text + "\n\n" + "A : Cette decision est mauvaise";
        } else if (evaluator.playerA < 0.6){
            scar.text = scar.text + "\n\n" + "A : Cette decision est moyenne";
        } else if (evaluator.playerA < 0.8){
            scar.text = scar.text + "\n\n" + "A : Cette decision est bonne";
        } else {
            scar.text = scar.text + "\n\n" + "A : Cette decision est parfaite";
        }

        if(evaluator.playerR < 0.2){
            scar.text = scar.text + "\n\n" + "R : Cette decision est grave";
        } else if (evaluator.playerR < 0.4){
            scar.text = scar.text + "\n\n" + "R : Cette decision est mauvaise";
        } else if (evaluator.playerR < 0.6){
            scar.text = scar.text + "\n\n" + "R : Cette decision est moyenne";
        } else if (evaluator.playerR < 0.8){
            scar.text = scar.text + "\n\n" + "R : Cette decision est bonne";
        } else {;
            scar.text = scar.text + "\n\n" + "R : Cette decision est parfaite";
        }


        //list in final the final score
        if (finalScore < 2)
        {
            final.text = "Vous avez mis le patient en danger";
        } else if (finalScore < 3)
        {
            final.text = "Vous avez très mal évalué le patient";
        } else if (finalScore < 4)
        {
            final.text = "Vous avez mal évalué le patient";
        } else if (finalScore < 5)
        {
            final.text = "Vous avez bien évalué le patient";
        } else if (finalScore < 6)
        {
            final.text = "Vous avez très bien évalué le patient";
        } else
        {
            final.text = "Vous avez sauvé le patient";
        }


        GameObject.Find("CanvasEnd").transform.position = new Vector3(1000, 1000, 1000);
    }
}
