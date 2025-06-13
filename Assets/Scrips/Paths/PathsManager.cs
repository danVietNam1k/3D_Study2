using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PathsManager : NewMonoBehaviour
{
    [SerializeField] List<PathControler> _listPaths = new();
    
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
        this.LoadListPaths();
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
