using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PathControler : NewMonoBehaviour
{

    [SerializeField] List<PointOnPath> _listPointOnPath = new();
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    protected override void LoadInReset()
    {
        base.LoadInReset();
        this.LoadListPointOnPath();
    }
    void LoadListPointOnPath()
    {
        _listPointOnPath.Clear();

        foreach (Transform child in this.transform)
        {
            PointOnPath c = child.GetComponent<PointOnPath>();
            _listPointOnPath.Add(c);
        }
    }

}
