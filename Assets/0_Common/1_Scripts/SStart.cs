using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SStart : MonoBehaviour
{

    public GameObject ParticleGame = null;

    public void Missile()
    {
        SMng.I.bStartChack = true;
        ParticleGame.SetActive(true);
        SSoundMng.I.Play("B", true, false);
    }

    public void Launch()
    {
        SSoundMng.I.Play("L", true, false);
    }
}
