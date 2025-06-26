using Unity.Jobs;
using Unity.VisualScripting;
using UnityEngine;

public abstract class SoundAbsTract : NewMonoBehaviour
{
    [SerializeField] protected SoundOfEnemy _nameSoundOfEnemy;
    [SerializeField] protected SoundOfPlayer _nameSoundOfPlayer;
    [SerializeField] protected SoundBG _nameSoundBG;

    [SerializeField] protected SoundCtrl SoundCtrl;
    [SerializeField] protected SoundManager SoundManager;
   protected AudioClip audioClip;
    protected float volume;
    protected override void LoadInReset()
    {
        base.LoadInReset();
        LoadComponent();
    }
    void LoadComponent()
    {
        
        SoundCtrl = GameObject.Find("SoundCtrl").GetComponent<SoundCtrl>();
        SoundManager = SoundCtrl.transform.GetComponentInParent<SoundManager>();

    }
    protected void Awake()
    {
        this.CheckLinked();
    }
    void CheckLinked()
    {
        if (!SoundCtrl || !SoundCtrl)
        {
            SoundManager = SoundManager.Instance;
            SoundCtrl = SoundManager.SoundCtrl;
        }
    }
    protected virtual void IsPlaySound()
    {
        if(_nameSoundOfEnemy != 0) {
            audioClip = SoundCtrl.ListEnemySfx[(int)_nameSoundOfEnemy];
            SoundManager.PlayAudio(this.transform, audioClip, volume);
            return;
        }
        if (_nameSoundOfPlayer != 0)
        {
            audioClip = SoundCtrl.ListPlayerSfx[(int)_nameSoundOfPlayer];
            SoundManager.PlayAudio(this.transform, audioClip, volume);
            return;
        }
        if (_nameSoundBG != 0)
        {
            audioClip = SoundCtrl.ListMusicBG[(int)_nameSoundBG];
            SoundManager.PlayAudio(this.transform, audioClip, volume);
        }

    }
}
