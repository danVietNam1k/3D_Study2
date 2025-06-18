using UnityEngine;

public class GameManager : Singleton<GameManager>
{
   

    [SerializeField] Transform _enemyManager, _pathsManager;
    public Transform EnemyManager => _enemyManager;
    public Transform PathsManager => _pathsManager;
    protected override void Awake()
    {
        base.Awake();
    }
    protected override void LoadInReset()
    {
        base.LoadInReset();
        this.LoadComponent();
       
    }
    void LoadComponent()
    {
        _enemyManager = GameObject.Find("EnemyManager").transform;
        _pathsManager = GameObject.Find("PathsManager").transform;

    }

}
