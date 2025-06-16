using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : NewMonoBehaviour
{
    [SerializeField] GameObject enemyManager;
    [SerializeField] List<GameObject> _listEnemyPrefab = new();
    [SerializeField] List<GameObject> _listEnemySpawn = new();

    [SerializeField] Transform _thisPointSpawn;
    protected override void LoadInReset()
    {
        base.LoadInReset();
        LoadListEnemy();
    }
    void LoadListEnemy()
    {
        enemyManager = GameObject.Find("EnemyManager");
        
        _thisPointSpawn = this.transform.Find("ThisPointSpawn");
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
       
        foreach (GameObject child in _listEnemySpawn)
        {
            
            if (child.activeSelf)
                continue;

            child.transform.position = _thisPointSpawn.position;
            child.SetActive(true);
            return child;

        }
        GameObject Enemy = Instantiate(RandomEnemy(), this.transform);
        Enemy.transform.position = _thisPointSpawn.position;
        _listEnemySpawn.Add(Enemy);
        return Enemy;
    }
    GameObject RandomEnemy()
    {   GameObject obj = _listEnemyPrefab[Random.Range(0, _listEnemyPrefab.Count)];

        return obj;
    }

}
