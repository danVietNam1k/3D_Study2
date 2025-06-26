using System.Collections;
using UnityEditor.Embree;
using UnityEngine;

public class StateEnemy : EnemyAbstract
{
    [SerializeField] int _maxHp = 100, _recieveHp;
    bool _isLive = true;
    void OnEnable()
    {
        ReActive();
    }
    protected override void LoadInReset()
    {
        base.LoadInReset();
    }
    void ReActive()
    {
        _recieveHp = _maxHp;
        _isLive = true;
        this.EnemyCtrl.Animator.SetBool("Dead", false);
    }
    public void TakeDame(int TakeDame)
    {
        //Debug.Log("a");
        this._recieveHp -= TakeDame;

        if (_recieveHp <= 0)
        {
            _recieveHp = 0;
            _isLive = false;
           
        }
        Animation();
    }
    public bool IsLive()
    {
        return _isLive;
    }
    protected virtual void Animation()
    {
        if (_isLive)
        {
            this.EnemyCtrl.Animator.SetTrigger("IsHurt");
            return;
        }
        else
        {
            this.EnemyCtrl.Animator.SetBool("Dead", true);

            StartCoroutine(WaitDead());
        }
    }
    IEnumerator WaitDead()
    {
        yield return new WaitForSeconds(2);
        this.transform.parent.gameObject.SetActive(false);
    }


}
