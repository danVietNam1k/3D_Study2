
using UnityEngine;

public class AimTarget : PlayerCtrAbstract
{
    //protected Vector3 maxDistance = new Vector3(0, 0, 50f);
    //[SerializeField] float _maxDistanceRay = 100f;
    //[SerializeField] LayerMask _laserMask = -1;
    [SerializeField] Transform _camera;
    [SerializeField] Transform _player;

  
    // Update is called once per frame
    void Update()
    {
        Pointing();
    }
    protected override void LoadInReset()
    {
        base.LoadInReset();
    }
    protected virtual void Pointing()
    {

        //Vector3 screenCentrer = new Vector3(Screen.width / 2f, Screen.height / 2,0);
        //Ray rayFromCenter = Camera.main.ScreenPointToRay(screenCentrer);
        //if (Physics.Raycast(rayFromCenter, out RaycastHit hit, _maxDistanceRay, _laserMask))
        //{
        //    this.transform.position = hit.point;
        //    Debug.Log("Hit: " + hit.collider.name);
        //    Debug.DrawRay(screenCentrer, hit.point,Color.red);
        //}
        //else
        //{
        //    this.transform.position = rayFromCenter.origin + rayFromCenter.direction * _maxDistanceRay;

        //}

        Vector3 player = _player.position + _player.transform.forward * 20f;
        Vector3 cam = _camera.position + _camera.transform.forward * 20f;
        
        if (this.PlayerCtrl.PlayerShooting.CheckisFire()){
            this.transform.position = cam;
            return;
        }
        this.transform.position = new Vector3(player.x, cam.y, player.z);





    }
}
        

