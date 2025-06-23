using System.Collections;
using TMPro.EditorUtilities;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _speed = 1f;
    Rigidbody rb;
    [SerializeField] int _dameBodyshot = 10, _dameHeadShot = 50;
    TrailRenderer tr;
    PoolSound _poolSound;
    private void Awake()
    {   
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<TrailRenderer>();
        
    }
    private void OnEnable()
    {
        ResetComponent();
        StartCoroutine(TimeActive());
        SoundFire();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = this.transform.forward * _speed;
    }
    
    IEnumerator TimeActive()
    {
        
        yield return new WaitForSeconds(1f);
        this.gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        SendDame(other);
        this.gameObject.SetActive(false);

    }
    void SendDame(Collider other)
    {
        if (other.CompareTag(CONSTANT.HeadEnemy)) {
            StateEnemy stateEnemy = other.transform.parent.Find("StateEnemy").GetComponent<StateEnemy>();
            stateEnemy.TakeDame(_dameHeadShot);
        }
        if (other.CompareTag(CONSTANT.BodyEnemy))
        {
            StateEnemy stateEnemy = other.transform.parent.Find("StateEnemy").GetComponent<StateEnemy>();
            stateEnemy.TakeDame(_dameBodyshot);
        }
        
    }
    private void ResetComponent()
    {
        tr.Clear();
    }
    void SoundFire()
    {
        _poolSound = GameObject.FindFirstObjectByType<PoolSound>();
        _poolSound.Audio(GameObject.Find("SoundFire"), this.transform);
    }

}
