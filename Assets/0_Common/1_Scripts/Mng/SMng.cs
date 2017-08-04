using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMng : MonoBehaviour
{
    private static SMng _Instance = null;

    public static SMng I
    {
        get
        {
            if (_Instance == null)
            {
                Debug.Log("instance is null");
            }
            return _Instance;
        }
    }

    void Awake()
    {
        _Instance = this;
        Screen.SetResolution(540, 960, false);
        DontDestroyOnLoad(transform.gameObject);
    }

    public bool bStartChack;
    public int nScoreCount;
}
