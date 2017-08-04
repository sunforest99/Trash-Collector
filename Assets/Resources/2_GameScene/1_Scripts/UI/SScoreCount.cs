using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SScoreCount : MonoBehaviour
{
    public STimer sTimerScrp = null;
    public SThrow ThrowScrp = null;
    public Text ScoreText = null;

    public GameObject FadeGame = null;
    public Image Img = null;

    bool bChack;
    // Use this for initialization
    void Start()
    {
        SMng.I.nScoreCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = SMng.I.nScoreCount.ToString();
        if (bChack)
        {
            FadeGame.SetActive(true);
            if (Img.color.a < 1f)
            {
                Img.color += new Color(0, 0, 0, 0.01f);
            }
            else
            {
                SceneManager.LoadScene(3);
                bChack = false;
            }//gameObject.SetActive(false);
        }

        // if (시간)
        //{

        //}
        if (sTimerScrp.fTimer < 0 && !SGameMng.I.bPause)
        {
            bChack = true;
            SGameMng.I.bPause = true;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Clear"))
        {
            ThrowScrp.Change();
            SGameMng.I.GetThrowCtrl.bScaleCheck = false;
            SGameMng.I.GetThrowCtrl.transform.localScale = new Vector3(1f, 1f, 1f);
            SMng.I.nScoreCount++;
            sTimerScrp.fTimer = 10f;
            SGameMng.I.bClearCheck = true;
            SSoundMng.I.Play("sound_paper_01", true, false);
        }
        if (col.gameObject.CompareTag("Over"))
        {
            sTimerScrp.fTimer -= 1f;
            sTimerScrp.nTime = (int)sTimerScrp.fTimer;
            sTimerScrp.nSeconds = sTimerScrp.nTime % 60;
            sTimerScrp.fMillisecond = sTimerScrp.fTimer * 100;
            sTimerScrp.fMillisecond = (sTimerScrp.fMillisecond % 100);
            sTimerScrp.TimerText.text = string.Format("{0:0}:{1:00}", sTimerScrp.nSeconds, sTimerScrp.fMillisecond);

            ThrowScrp.Change();
            SGameMng.I.GetThrowCtrl.bScaleCheck = false;
            SGameMng.I.GetThrowCtrl.transform.localScale = new Vector3(1f, 1f, 1f);
            SGameMng.I.bClearCheck = true;
            //SGameMng.I.SResultScrp.ScoreText.enabled = true;
            //SGameMng.I.SResultScrp.HighScore.enabled = true;
            //SGameMng.I.bPause = true;
            //SGameMng.I.bThrowCheck = false;

            //SGameMng.I.SResultScrp.ResultGame.transform.localPosition = new Vector2(0f, 0f);
        }
    }
}
