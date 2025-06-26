using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class endState : StateMachineBehaviour
{
    [SerializeField] SoundOfPlayer _typeSoundOfPlayer;
    [SerializeField,Range(0,1)] float volume = 1.0f;
    AudioClip clip;
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        clip = SoundManager.Instance.SoundCtrl.ListPlayerSfx[(int)_typeSoundOfPlayer];
        SoundManager.Instance.PlayAudio(PlayerCtrl.Instance.transform, clip, volume);
    }
}
