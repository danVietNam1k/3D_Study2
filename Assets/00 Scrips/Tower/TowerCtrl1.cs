using UnityEngine;

public class TowerCtrl : NewMonoBehaviour
{
    
    [SerializeField] Transform _model, _rotateHeadGunMachine, _firePoint;
    public Transform Model => _model;
    public Transform RotateHeadGunMachine => _rotateHeadGunMachine;
    [SerializeField]
    TowerBehaviour _targetEnemy;
    public TowerBehaviour TowerBehaviour => _targetEnemy;
    public Transform FirePoint => _firePoint;
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
        this.LoadModel();
       
    }
    void LoadModel()
    {
        _model = this.transform.GetChild(0).transform;
        _rotateHeadGunMachine = _model.Find("MGMain");
        _targetEnemy = this.transform.GetComponentInChildren<TowerBehaviour>();
        _firePoint = this._rotateHeadGunMachine.Find("Fire");

    }
    
}
