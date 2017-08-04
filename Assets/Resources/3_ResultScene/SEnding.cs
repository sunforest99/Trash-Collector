using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SEnding : MonoBehaviour
{
    public Text fText;
    public Text sText;
    public Text ScoreText;

    public string[] sFending;
    public string[] sSending;
    int nRandom;

    // Use this for initialization
    void Start()
    {
        nRandom = Random.Range(0, 20);
        fText.text = sFending[nRandom];
        sText.text = sSending[nRandom];
        ScoreText.text = "Score :  " + SMng.I.nScoreCount.ToString();
    }
}
