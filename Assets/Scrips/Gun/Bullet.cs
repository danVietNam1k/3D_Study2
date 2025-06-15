using System.Collections;
using TMPro.EditorUtilities;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _speed = 1f;
    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        StartCoroutine(TimeActive());
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
       Debug.LogError("Bullet Ontriger"+other.name);
        if(other.CompareTag("BodyEnemy") || other.CompareTag("HeadEnemy"))
        this.gameObject.SetActive(false);
    }

}
