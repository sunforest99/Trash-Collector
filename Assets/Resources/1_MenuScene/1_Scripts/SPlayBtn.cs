using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SPlayBtn : MonoBehaviour
{
    bool bCheck;
    public Image Img;
    public GameObject FadeGame = null;

    public GameObject AnimationGame = null;

    public Animation MoveUIAni = null;

    public void PlayBtn()
    {
        MoveUIAni.Play();
        AnimationGame.SetActive(true);
        bCheck = true;
    }

    void Start()
    {
        bCheck = false;
    }

    void Update()
    {
        if (SMng.I.bStartChack)
        {
            AnimationGame.SetActive(true);
            FadeGame.SetActive(true);
            if (bCheck == true)
            {
                if (Img.color.a < 1f)
                {
                    Img.color += new Color(0, 0, 0, 0.01f);
                }
                else
                    SceneManager.LoadScene("2_GameScene");
            }
        }
    }
}
