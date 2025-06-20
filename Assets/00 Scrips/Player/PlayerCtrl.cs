using UnityEngine;

public class PlayerCtrl : NewMonoBehaviour
{
    [SerializeField] InputManager _inputManager;
    public InputManager InputManager => _inputManager;
    [SerializeField] BulletManager _bulletManager;
    public BulletManager BulletManager => _bulletManager;

    [SerializeField] AimBehaviourBasic _aimBehaviourBasic;
    public AimBehaviourBasic AimBehaviourBasic => _aimBehaviourBasic;
    [SerializeField] Transform _rigging;
    public Transform Rigging => _rigging;
    [SerializeField] Transform _ak47;
    public Transform AK47 => _ak47;
    [SerializeField] Transform _mainCam;
    public Transform MainCam => _mainCam;
    [SerializeField] PlayerShooting _playerShooting;
    public PlayerShooting PlayerShooting => _playerShooting;
    protected override void LoadInReset()
    {
        base.LoadInReset();
        _rigging = GameObject.Find("RiggingPlayer").transform;
        _aimBehaviourBasic = GetComponent<AimBehaviourBasic>();
        _ak47 = GameObject.Find("Ak47").transform;
        _inputManager = GameObject.FindFirstObjectByType<InputManager>();
        _bulletManager = GameObject.FindFirstObjectByType<BulletManager>();
        _mainCam = GameObject.FindFirstObjectByType<ThirdPersonOrbitCamBasic>().transform;
        _playerShooting = GameObject.FindFirstObjectByType<PlayerShooting>();
    }
}
