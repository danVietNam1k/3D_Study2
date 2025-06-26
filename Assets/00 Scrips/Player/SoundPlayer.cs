using UnityEngine;

public class SoundPlayer : NewMonoBehaviour
{
    [SerializeField] SoundWalkSfxPlayer _soundWalkSfxPlayer;
    [SerializeField] SoundRunSfxPlayer _soundRunSfxPlayer;
    protected override void LoadInReset()
    {
        base.LoadInReset();
        this.LoadComponent();
    }
    void LoadComponent()
    {
        _soundWalkSfxPlayer = this.transform.Find("Sound").GetComponent<SoundWalkSfxPlayer>();
        _soundRunSfxPlayer = this.transform.Find("Sound").GetComponent<SoundRunSfxPlayer>();
    }
    public void PlaySoundRun()
    {
        _soundRunSfxPlayer.RunSfx();
    }
    public void PlaySoundWalk()
    {
        _soundWalkSfxPlayer.WalkSfx();
    }
}
