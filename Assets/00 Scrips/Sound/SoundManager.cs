
using System;

using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class SoundManager : NewMonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance => instance;
    public PoolSound PoolSound;
    public SoundCtrl SoundCtrl;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        if (instance.GetInstanceID() != this.GetInstanceID())
        {
            Debug.LogError("have two SoundManager");
            Destroy(gameObject);
        }
        
    }
    protected override void LoadInReset()
    {
        base.LoadInReset();
        this.PoolSound = this.transform.Find("PoolSound").GetComponent<PoolSound>();
        SoundCtrl = this.transform.Find("SoundCtrl").GetComponent<SoundCtrl>();
    }
    public void PlayAudio(Transform thisPosition, AudioClip audioClip, float volume = 1)
    {
        PoolSound.PoolAudio(thisPosition, audioClip, volume);
    }
    
}
