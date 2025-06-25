using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class SoundCtrl : MonoBehaviour
{
    [SerializeField] AudioClip[] _playerSoundSfx;
    public AudioClip[] ListPlayerSfx => _playerSoundSfx;
    [SerializeField] AudioClip[] _EnemySoundSfx;
    public AudioClip[] ListEnemySfx => _EnemySoundSfx;
    [SerializeField] AudioClip[] _musicBG ;
    public AudioClip[] ListMusicBG => _musicBG;

}
