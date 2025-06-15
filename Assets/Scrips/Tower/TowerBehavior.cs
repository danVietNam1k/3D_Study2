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
        LookAtNearestTarget();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("in" + other.transform.parent.name);
            _listEnemy.Add(other.gameObject.transform);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("out"+other.transform.parent.name);
            _listEnemy.Remove(other.gameObject.transform);
        }
    }
    void LookAtNearestTarget()
    {
       Invoke(nameof(LookAtNearestTarget),1f);
        float thisNearest = Mathf.Infinity;
        if(_listEnemy.Count == 0) {
            _thisTowerCheck = null;
            return;
        }
            
        foreach (Transform child in _listEnemy)
        { float distance = Vector3.Distance(child.transform.position, this.transform.position);
            if (distance < thisNearest)
            {
                Debug.Log("take enemy");
                thisNearest = distance;
                _thisTowerCheck = child.GetComponent<TowerCheck>();
            }
        }

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
