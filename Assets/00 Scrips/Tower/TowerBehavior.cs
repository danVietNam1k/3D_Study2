using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof(Rigidbody))]
[RequireComponent (typeof (SphereCollider))]
public class TowerBehaviour : NewMonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] SphereCollider sphereCollider;
    
    [SerializeField] List<Transform> _listEnemy = new();
    [SerializeField] TowerCheck _thisTowerCheck;
    public TowerCheck TowerCheck =>_thisTowerCheck;
    [SerializeField] LayerMask _layerMask;
    void Start()
    {
        LookAtNearestTarget();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            _listEnemy.Add(other.gameObject.transform);
        }
       
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            _listEnemy.Remove(other.gameObject.transform);
        }
    }
    void LookAtNearestTarget()
    {
        Invoke(nameof(LookAtNearestTarget),0.2f);
        float thisNearest = Mathf.Infinity;
        if(_listEnemy.Count < 1) {
            _thisTowerCheck = null;
           
            return;
        }

        foreach (Transform child in _listEnemy)
        {
            float distance = Vector3.Distance(child.transform.position, this.transform.position);
            if (child.parent.Find("StateEnemy").GetComponent<StateEnemy>().IsLive())
            {
                if (!CanSeeEnemy(child)) continue;
                if (distance < thisNearest)
                {
                    thisNearest = distance;
                    _thisTowerCheck = child.GetComponent<TowerCheck>();
                }
            }

        }

    }
    bool CanSeeEnemy(Transform obj)
    {
        Vector3 directionToTarget = obj.transform.position- this.transform.position;    
        float distanceToTarget = directionToTarget.magnitude;
        if (!Physics.Raycast(transform.position, directionToTarget, out RaycastHit hitInfo, distanceToTarget, _layerMask))
        {
            return false;
        }
        return true;
    }
    protected override void LoadInReset()
    {
        base.LoadInReset();
        this.LoadRigibody();
        this.LoadSphereCollider();
    }
    void LoadRigibody()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;

    }
    void LoadSphereCollider()
    {
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.radius = 5f;
        sphereCollider.isTrigger = true;

    }
}
