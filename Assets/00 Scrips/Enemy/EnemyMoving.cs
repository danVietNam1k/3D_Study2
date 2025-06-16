using UnityEngine;
using UnityEngine.AI;

public class EnemyMoving : EnemyAbstract
{
    [SerializeField] Transform _target, _point, _PathsManager;
    [SerializeField] NavMeshAgent _Agent;
    [SerializeField] float _changePoint;
    [SerializeField] Animator _animator;
    
    
    void OnEnable()
    {
        this.GetTarget();
        
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
        
        this.GetComponient();

    }
    void GetComponient()
    {
        
        _animator = EnemyCtrl.Animator;
        this._Agent = this.transform.GetComponentInParent<NavMeshAgent>();
        _PathsManager = GameObject.Find("PathsManager").transform;


    }
    void TakePathRandom()
    {
        int ramdom = Random.Range(0, _PathsManager.childCount);
        _point = _PathsManager.GetChild(ramdom).transform;

    }
    void GetTarget()
    {
        TakePathRandom();
        _Agent.isStopped = false;
        if (_Agent == null)
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
        if (!EnemyCtrl.StateEnemy.IsLive())
        {
            _Agent.isStopped = true;
            return;
        }
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
