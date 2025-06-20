using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BulletManager : Singleton<BulletManager>
{
    [SerializeField] List<GameObject> _listobj = new();
    public GameObject Bullet(GameObject prefab, Transform FirePoint, Transform thisRotate)
    {
        foreach (GameObject child in _listobj)
        {
            if (child.activeSelf)
                continue;
            child.transform.position = FirePoint.position;
            child.transform.rotation = thisRotate.rotation;
            child.SetActive(true);
            return child;

        }
        GameObject obj = Instantiate(prefab, this.transform);
        obj.SetActive(false);
        obj.transform.position = FirePoint.position;
        obj.transform.rotation = thisRotate.rotation;
        _listobj.Add(obj);
        obj.SetActive(true);
        return obj;
    }
}
