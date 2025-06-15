using UnityEngine;

public abstract class TowerAbstract : NewMonoBehaviour
{
    [SerializeField ]protected TowerCtrl TowerCtrl;
 
    protected override void LoadInReset()
    {
        base.LoadInReset();
        this.LoadComponent();
    }
    void LoadComponent()
    {
        TowerCtrl = this.GetComponentInParent<TowerCtrl>();
        
    }

}
