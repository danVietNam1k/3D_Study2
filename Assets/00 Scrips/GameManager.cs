using UnityEngine;

public class GameManager : NewMonoBehaviour
{
    [SerializeField] private static GameManager instance;
    public static GameManager Instance => instance;

    [SerializeField] Transform _enemyManager, _pathsManager;
    public Transform EnemyManager => _enemyManager;
    public Transform PathsManager => _pathsManager;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        if (this.gameObject.GetInstanceID() != GameManager.Instance.gameObject.GetInstanceID())
        {
            Destroy(gameObject);
        }
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
