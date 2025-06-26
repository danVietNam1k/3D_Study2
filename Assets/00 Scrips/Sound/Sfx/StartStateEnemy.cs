using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class StartStateEnemy : StateMachineBehaviour
{
    [SerializeField] SoundOfEnemy _typeSoundOfEnemy;
    [SerializeField,Range(0,1)] float volume = 1.0f;
    AudioClip clip;  
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        clip = SoundManager.Instance.SoundCtrl.ListEnemySfx[(int)_typeSoundOfEnemy];
        SoundManager.Instance.PlayAudio(PlayerCtrl.Instance.transform, clip, volume);
    }
}
