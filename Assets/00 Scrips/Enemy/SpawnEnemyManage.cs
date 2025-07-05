using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyManage : NewMonoBehaviour
{
    public static SpawnEnemyManage Instance;
    [SerializeField] GameObject enemyManager;
    [SerializeField] List<GameObject> _listEnemyPrefab = new();
    [SerializeField] List<GameObject> _listEnemySpawn = new();

    [SerializeField] List<Transform> _thisPointSpawn = new();
    int _point;
    private void Awake()
    {
        Instance = this;
    }
    protected override void LoadInReset()
    {
        base.LoadInReset();
        LoadListEnemy();
        LoadPointSpawn();
    }
    void LoadListEnemy()
    {
        enemyManager = GameObject.Find("EnemyManager");
        foreach (Transform transform in enemyManager.transform)
        {
            _listEnemyPrefab.Add(transform.gameObject);
        }
    }
    private void Start()
    {
        Spawm();
    }
    void Spawm()
    {
        Invoke(nameof(Spawm), 1f);
        Enemy();

    }
    GameObject Enemy()
    {
        _point = Random.Range(0, _thisPointSpawn.Count);

        Transform thisSpawn = _thisPointSpawn[_point];
        foreach (GameObject child in _listEnemySpawn)
        {
            
            if (child.activeSelf)
                continue;

            child.transform.position = thisSpawn.position;
            child.SetActive(true);
            return child;

        }
        GameObject Enemy = Instantiate(RandomEnemy(), this.transform);
        Enemy.transform.position = thisSpawn.position;
        Enemy.SetActive(true);
        _listEnemySpawn.Add(Enemy);
        return Enemy;
    }
    public int GivePoint()
    {
        return _point;
    }
    GameObject RandomEnemy()
    {   GameObject obj = _listEnemyPrefab[Random.Range(0, _listEnemyPrefab.Count)];

        return obj;
    }
    void LoadPointSpawn()
    {
        foreach (Transform child in this.transform)
        {
            _thisPointSpawn.Add(child);
        }
    }

}
