using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Shootting : TowerAbstract
{
    [SerializeField] Transform _firePoint;
    int _currentFirePoint = 0;
    [SerializeField] GameObject _bullet;
    List<GameObject> _listBullet = new();
    void Start()
    {
        Shooting();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected override void LoadInReset()
    {
        base.LoadInReset();
        this.LoadComponent();
    }
    void LoadComponent()
    {
        _firePoint = this.TowerCtrl.FirePoint;
    }
    void Shooting()
    {
        Invoke(nameof(Shooting), 0.3f);
        if (this.TowerCtrl.TowerBehaviour.TowerCheck == null) return;
        Debug.Log("Shoot");
        bullet();
    }
    Transform FirePoint()
    {
        
        Transform firePoint = _firePoint.GetChild(_currentFirePoint).transform;
        _currentFirePoint++;
        if (_currentFirePoint == _firePoint.childCount) _currentFirePoint = 0;

        return firePoint;
    }
    GameObject bullet()
    {
        foreach(GameObject child in _listBullet)
        {
            if (child.activeSelf)
                continue;          
            
                child.transform.position = FirePoint().position;
                child.transform.rotation = this.TowerCtrl.Rotate.rotation;
                child.SetActive(true);
                return child;
                     
        }
        GameObject Bullet = Instantiate(_bullet,this.transform);
        Bullet.transform.position = FirePoint().position;
        Bullet.transform.rotation = this.TowerCtrl.Rotate.rotation;
        _listBullet.Add(Bullet);
        return Bullet;
    }
}
