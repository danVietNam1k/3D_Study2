using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class PoolSound : NewMonoBehaviour
{
    [SerializeField] private GameObject AudioSource;
    [SerializeField] List<GameObject> _objPooling = new();
    protected override void LoadInReset()
    {
        base.LoadInReset();
        this.AudioSource = this.transform.parent.Find("AudioSource").gameObject;
    }
    public GameObject PoolAudio(Transform thisPosition, AudioClip audioClip, float volume = 1)
    {
        foreach (GameObject child in _objPooling)
        {
            if (child.GetComponent<AudioSource>().isPlaying)
                continue;
            child.transform.GetComponent<AudioSource>().clip = audioClip;
            //child.transform.GetComponent<AudioSource>().outputAudioMixerGroup = SoundManager1.Instance.SoundList.mixer ;
            child.transform.position = thisPosition.position;
            child.GetComponent<AudioSource>().Play();
            return child;
        }
        GameObject obj = Instantiate(AudioSource, this.transform);
        obj.SetActive(false);
        obj.transform.position = thisPosition.position;
        //obj.transform.GetComponent<AudioSource>().outputAudioMixerGroup = SoundManager1.Instance.SoundList.mixer;
        obj.transform.GetComponent<AudioSource>().clip = audioClip;
        _objPooling.Add(obj);
        obj.SetActive(true);
        obj.GetComponent<AudioSource>().Play();
        return obj;
    }
    
}
