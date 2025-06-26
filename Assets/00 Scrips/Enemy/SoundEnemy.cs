using UnityEngine;

public class SoundEnemy : NewMonoBehaviour
{
    [SerializeField] SoundRunSfxEnemy _soundWalkSfxEnemy;
    [SerializeField] SoundHurtSfxEnemy _soundHurtSfxEnemy;
    [SerializeField] SoundDeadSfxEnemy _soundDeadSfxEnemy;
    protected override void LoadInReset()
    {
        base.LoadInReset();
        this.LoadComponent();
    }
    void LoadComponent()
    {
        _soundWalkSfxEnemy = this.transform.parent.Find("Sound").GetComponent<SoundRunSfxEnemy>();
        _soundHurtSfxEnemy = this.transform.parent.Find("Sound").GetComponent<SoundHurtSfxEnemy>();
        _soundDeadSfxEnemy = this.transform.parent.Find("Sound").GetComponent<SoundDeadSfxEnemy>();
    }
    public void PlaySoundRun()
    {
        _soundWalkSfxEnemy.RunSfx();
    }
    public void PlaySoundHurt()
    {
        _soundHurtSfxEnemy.HurtSfx();
    }
    public void PlaySoundDead()
    {
        _soundDeadSfxEnemy.DeadSfx();
    }
}
