using UnityEngine;

public class SoundBullet : SoundAbsTract
{
    protected override void LoadInReset()
    {
        base.LoadInReset();
    }
    private void OnEnable()
    {
        IsPlaySound();
    }


}
