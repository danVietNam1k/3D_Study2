using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof(Rigidbody))]
[RequireComponent (typeof (SphereCollider))]
public class TowerBehaviour : NewMonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] SphereCollider sphereCollider;
    [SerializeField] float radius =5f;
    [SerializeField] List<GameObject> _listEnemy = new();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("in" + other.transform.parent.name);
            _listEnemy.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("out"+other.transform.parent.name);
            _listEnemy.Remove(other.gameObject);
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
        sphereCollider.radius = radius;
        sphereCollider.isTrigger = true;

    }
}
