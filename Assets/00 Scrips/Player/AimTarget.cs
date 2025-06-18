using UnityEngine;

public class AimTarget : MonoBehaviour
{
    protected Vector3 maxDistance = new Vector3(0,0,50f);
    [SerializeField] LayerMask _laserMask;
    [SerializeField] Transform _camera;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Pointing();
    }
    protected virtual void Pointing()
    {
        this.transform.position = _camera.position + _camera.transform.forward *10f;
        this.transform.rotation = _camera.rotation;
    }
}
