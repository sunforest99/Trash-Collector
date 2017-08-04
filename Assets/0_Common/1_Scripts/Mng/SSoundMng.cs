using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSoundMng : MonoBehaviour
{
    public AudioSource MainAudio = null;
    [SerializeField]
    AudioSource EffectAudio = null;
    [SerializeField]
    AudioSource EffectAudio2 = null;
    [SerializeField]
    AudioClip[] SoundClip = null;

    private static SSoundMng _Instance = null;

    public bool bBackGroundSound;        // false = play, true = stop;
    public bool bEffectSound;            // false = play, true = stop;
    public static SSoundMng I
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
        StartCoroutine("SoundCtrl");
        DontDestroyOnLoad(transform.gameObject);
    }

    public void Play(string sSoundName, bool bEffectAudio, bool bAutoPlay)      // play parameters ( need soundname , choice effect(true) or bgm(false), bgm(true) Effectsound(false) )
    {
        if (bAutoPlay.Equals(true))
        {
            MainAudio.playOnAwake = true;
            MainAudio.loop = true;
        }

        for (int i = 0; i < SoundClip.Length; i++)
        {
            if (!bEffectAudio && SoundClip[i].name.Equals(sSoundName))
            {
                MainAudio.clip = SoundClip[i];
                MainAudio.Play();
            }
            else if (!EffectAudio.isPlaying && bEffectAudio && SoundClip[i].name.Equals(sSoundName))
            {
                EffectAudio.clip = SoundClip[i];
                EffectAudio.Play();
            }
            else if (EffectAudio.isPlaying && bEffectAudio && SoundClip[i].name.Equals(sSoundName))
            {
                EffectAudio2.clip = SoundClip[i];
                EffectAudio2.Play();
            }
        }
    }

    void SoundOff()
    {
        if (!bBackGroundSound)
        {
            MainAudio.enabled = true;
        }
        else
        {
            MainAudio.enabled = false;
        }

        if (!bEffectSound)
        {
            EffectAudio.enabled = true;
            EffectAudio2.enabled = true;
        }
        else
        {
            EffectAudio.enabled = false;
            EffectAudio2.enabled = false;

            EffectAudio.clip = null;
            EffectAudio2.clip = null;
        }
    }

    IEnumerator SoundCtrl()
    {
        yield return null;
        SoundOff();

        StartCoroutine("SoundCtrl");
    }
}
