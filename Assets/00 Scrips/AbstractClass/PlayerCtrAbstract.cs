using UnityEngine;

public class PlayerCtrAbstract : NewMonoBehaviour
{
    [SerializeField] PlayerCtrl _playerCtrl;
    public PlayerCtrl PlayerCtrl => _playerCtrl;
    protected override void LoadInReset()
    {
        base.LoadInReset();
        _playerCtrl = GetComponent<PlayerCtrl>();
    }
}
