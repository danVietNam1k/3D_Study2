using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class PoolSound : NewMonoBehaviour
{
    [SerializeField] List<GameObject> _objPooling = new();
    public GameObject Audio(GameObject prefab, Transform thisPosition)
    {
        foreach (GameObject child in _objPooling)
        {
            if (child.activeSelf)
                continue;
            child.transform.position = thisPosition.position;
            child.SetActive(true);
            child.GetComponent<AudioSource>().Play();
            return child;

        }
        GameObject obj = Instantiate(prefab, this.transform);
        obj.SetActive(false);
        obj.transform.position = thisPosition.position;
        _objPooling.Add(obj);
        obj.SetActive(true);
        obj.GetComponent<AudioSource>().Play();
        return obj;
    }
}
