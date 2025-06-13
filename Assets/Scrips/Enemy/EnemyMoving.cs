using UnityEngine;
using UnityEngine.AI;

public class EnemyMoving : NewMonoBehaviour
{
    [SerializeField] Transform _target, _point;
    [SerializeField] NavMeshAgent _Agent;
    [SerializeField] float _changePoint;
    [SerializeField] bool _isMoving;
    [SerializeField] Animator _animator;
    [SerializeField] EnemyCtrl enemyCtrl;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
        Anim();
        GetNextPoint();
    }
    protected override void LoadInReset()
    {
        base.LoadInReset();
        this.GetTarget();
        this.GetComponient();


    }
    void GetComponient()
    {
        enemyCtrl = this.GetComponentInParent<EnemyCtrl>();
        _animator = enemyCtrl.Animator;
    }
    void GetTarget()
    {
        if (_Agent == null)
        this._Agent = this.transform.GetComponentInParent<NavMeshAgent>();
        _point = GameObject.Find("Path_0").GetComponent<Transform>();
        _target = null;
        if(_target == null) 
            _target = _point.GetChild(0);

    }
    void GetNextPoint()
    {
        if (_target.GetComponent<PointOnPath>().NextPoint == null) return;
            _changePoint = Vector3.Distance(this.transform.position, _target.position);
        if (_changePoint < 2f) { 
        
            
            _target = _target.GetComponent<PointOnPath>().NextPoint;
        }


    }
    void Moving()
    {
        
        if (_target == null) return;
            _Agent.SetDestination(_target.position); 
    


    }
    void Anim()
    {
        if(_Agent.velocity.magnitude != 0f)
            _animator.SetBool("isMoving",true);
        else
            _animator.SetBool("isMoving", false);


    }
}
