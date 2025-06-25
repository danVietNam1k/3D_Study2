using UnityEngine;

public class PlaySoundEnter : StateMachineBehaviour
{
    
    [SerializeField, Range(0, 1)] private float volume = 1;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SoundManager.Instance.PoolSound.PoolAudio(PlayerCtrl.Instance.transform, null, volume);
    }
}

