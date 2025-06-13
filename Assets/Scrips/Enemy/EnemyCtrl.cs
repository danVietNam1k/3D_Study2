using UnityEngine;

public class EnemyCtrl : NewMonoBehaviour
{

    [SerializeField] Transform _model;
    [SerializeField] Animator _animator;
    public Animator Animator => _animator;
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


    }
    protected override void LoadInReset()
    {
        base.LoadInReset();
        this.LoadComponient();
    }
}
