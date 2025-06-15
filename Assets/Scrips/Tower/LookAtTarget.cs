using UnityEngine;

public class LookAtTarget : TowerAbstract
{ 
    [SerializeField] float _rotateSpeed;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    protected override void LoadInReset()
    {
        base.LoadInReset();
        
    }
    private void FixedUpdate()
    {
        LookAtThisTarget();
    }
    void LookAtThisTarget()
    {
        if (this.TowerCtrl.TowerBehaviour.TowerCheck== null) return;
        Vector3 taget = this.TowerCtrl.TowerBehaviour.TowerCheck.transform.position;
        Vector3 directionToTarget = taget - this.transform.position;
        Vector3 newDrection = Vector3.RotateTowards(
            this.TowerCtrl.Rotate.forward,
            directionToTarget,
            _rotateSpeed * Time.fixedDeltaTime, 
            0f
            );
        this.TowerCtrl.Rotate.rotation = Quaternion.LookRotation(newDrection);
        //this.TowerCtrl.Rotate.LookAt(towerBehaviour.TowerCheck.transform.position);
    }
}
