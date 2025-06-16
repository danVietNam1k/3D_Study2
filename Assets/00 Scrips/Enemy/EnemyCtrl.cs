using Unity.VisualScripting;
using UnityEngine;

public class EnemyCtrl : NewMonoBehaviour
{

    [SerializeField] Transform _model;
    [SerializeField] Animator _animator;
    public Animator Animator => _animator;
    [SerializeField] TowerCheck towerCheck;
    public TowerCheck TowerCheck => towerCheck;
    [SerializeField] StateEnemy stateEnemy;
    public StateEnemy StateEnemy => stateEnemy;
    void LoadComponient() {
        _model = this.transform.GetChild(0).transform;
        _animator = _model.GetComponent<Animator>();
        towerCheck = this.transform.GetComponentInChildren<TowerCheck>();
        stateEnemy = this.transform.GetComponentInChildren<StateEnemy>();
    }
    protected override void LoadInReset()
    {
        base.LoadInReset();
        this.LoadComponient();
    }
}
