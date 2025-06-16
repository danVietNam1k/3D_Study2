using UnityEngine;

public abstract class EnemyAbstract : NewMonoBehaviour
{
    [SerializeField] protected EnemyCtrl enemyCtrl;
    public EnemyCtrl EnemyCtrl => enemyCtrl;
    protected override void LoadInReset()
    {
        base.LoadInReset();
        enemyCtrl = this.transform.GetComponentInParent<EnemyCtrl>();

    }
}

