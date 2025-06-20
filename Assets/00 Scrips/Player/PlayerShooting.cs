using System.Collections;
using UnityEngine;

public class PlayerShooting : PlayerCtrAbstract
{
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Transform _firePoit, _thisRotate;
    [SerializeField] float _speedFire=0.1f;
    bool _isFire = false;
    [SerializeField] Transform _camMain;

    void Start()
    {
        
        _thisRotate = this.transform.parent.Find("PlayerMainCamera");
        //_firePoit = _thisRotate.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        PressAtkButton();
    }
    void PressAtkButton()
    {
        if (_isFire) return;
        if(!this.PlayerCtrl.AimBehaviourBasic.CheckAiming()) return;

        if(this.PlayerCtrl.InputManager.PlayerAttack())
        {
            this.PlayerCtrl.BulletManager.Bullet(_bulletPrefab, _firePoit, _thisRotate);
           
        }
        _isFire = true ;
        StartCoroutine(ShootDelay());
    }
    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(_speedFire);
        _isFire = false;
    }
    public bool CheckisFire()
    {
        return _isFire;
    }
   
}
