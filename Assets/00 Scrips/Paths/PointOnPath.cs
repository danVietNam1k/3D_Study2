using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PointOnPath : NewMonoBehaviour
{
    [SerializeField] Transform _nextPoint;
    public Transform NextPoint => _nextPoint;
    
    protected override void LoadInReset()
    {
        base.LoadInReset();
        this.NextPointTarget();
    }
    void NextPointTarget()
    {
        Transform _thisParent = this.transform.parent;
        for (int i = 0; i< _thisParent.childCount; i++) 
        {
            if (this.transform == _thisParent.GetChild(i))
            {
                if (_nextPoint == _thisParent.GetChild(i + 1)) return;

                _nextPoint = _thisParent.GetChild(i + 1);
            }
        }
    }
}
