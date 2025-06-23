using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : NewMonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance => instance;

    [SerializeField] List<Transform> _ListSoundSfx , _ListMusicBG;
    
    public List<Transform> ListSoundSfx => _ListSoundSfx;
    [SerializeField] Transform _musicBG, _sfxSound, _poolSound;
    public Transform MusicBH => _musicBG;
    public Transform SfxSound => _sfxSound;
    public Transform PoolSound => _poolSound;
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
        LoadChild();
        this.LoadListAudio();
    }

    void LoadChild()
    {
        _musicBG = this.transform.Find("MusicBG");
        _sfxSound = this.transform.Find("SfxSound");
        _poolSound = this.transform.Find("PoolSound");
    }

    void LoadListAudio()
    {
        LoadMusicBH();
        LoadSFX();
    }
    void LoadMusicBH()
    {
        foreach (Transform audio in _musicBG)
            _ListMusicBG.Add(audio);
    }
    void LoadSFX()
    {
        foreach (Transform sound in _sfxSound)
            _ListSoundSfx.Add(sound);
    
    }
    void Update()
    {
        
    }
}
