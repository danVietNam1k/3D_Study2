using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    protected override void Awake() {
    base.Awake();
    }
    protected bool _playerAiming = false;
    protected bool _playerAttack = false;
    void Update()
    {
        CheckInput();
    }
    protected virtual void CheckInput() {
      
       this._playerAttack = Input.GetMouseButton(0);
        this._playerAiming = Input.GetMouseButton(1);
    }
    protected virtual bool PlayerAiming()
    {
        
        return this._playerAiming;
    }
    public virtual bool PlayerAttack()
    {

        return this._playerAttack;
    }
}
