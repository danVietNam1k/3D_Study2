using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PathsManager : NewMonoBehaviour
{   private static PathsManager instance;
    public static PathsManager Instance => instance;

    [SerializeField] List<PathControler> _listPaths = new();
    protected override void LoadInReset()
    {
        base.LoadInReset();
        this.LoadListPaths();
        instance = this;
    }
    private void Awake()
    {
         instance = this;
    }
    void LoadListPaths()
    {
        _listPaths.Clear();
       
        foreach (Transform child in this.transform)
        {
            PathControler c = child.GetComponent<PathControler>();
            _listPaths.Add(c);
        }
    }
   
}
