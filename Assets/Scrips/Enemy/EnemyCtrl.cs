using Unity.VisualScripting;
using UnityEngine;

public class EnemyCtrl : NewMonoBehaviour
{

    [SerializeField] Transform _model;
    [SerializeField] Animator _animator;
    public Animator Animator => _animator;
    [SerializeField] TowerCheck towerCheck;
    public TowerCheck TowerCheck => towerCheck;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LoadComponient() {
        _model = this.transform.GetChild(0).transform;
        _animator = _model.GetComponent<Animator>();
        towerCheck = this.transform.GetComponentInChildren<TowerCheck>();
    }
    protected override void LoadInReset()
    {
        base.LoadInReset();
        this.LoadComponient();
    }
}
