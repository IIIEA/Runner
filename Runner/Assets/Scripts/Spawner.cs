using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectsPool
{
    [SerializeField] private GameObject _enemyTemplate;
    [SerializeField] private float _delayBetweenSpawn;
    [SerializeField] private List<Transform> _spawnPoints;

    private float _elapsedTime = 0;
    private Transform[] _points;

    private void Awake()
    {
        Initialize(_enemyTemplate);
    }

    private void Start()
    {
        _points = GetComponentsInChildren<Transform>();

        for (int i = 1; i < _points.Length; i++)
        {
            _spawnPoints.Add(_points[i]);
        }
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if(_elapsedTime >= _delayBetweenSpawn)
        {
            if (TryGetObject(out GameObject enemy))
            {
                _elapsedTime = 0;

                int spawnPointNumber = Random.Range(0, _spawnPoints.Count);

                SetEnemyActivity(enemy, _spawnPoints[spawnPointNumber].position);
            }
        }
    }

    private void SetEnemyActivity(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
    }
}
