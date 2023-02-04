using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Player _player;

    private Wave _currentWave;
    private int _currentWaveNumber = 0;
    private float _timeAfterLastSpawn;
    private int _spawned;
    private int _pointNumber = 0;

    public event UnityAction AllEnemySpawned;

    private void Start()
    {
        SetWave(_currentWaveNumber);
    }

    private void Update()
    {
        if (_currentWave == null)
        {
            return;
        }

        _timeAfterLastSpawn += Time.deltaTime;

        if (_timeAfterLastSpawn >= _currentWave.Delay)
        {
            _pointNumber = GetRandomePointSpawn();
            InstantiateEnemy();
            _spawned++;
        }

        if (_currentWave.Count <= _spawned)
        {
            if (_waves.Count > _currentWaveNumber + 1)
            {
                AllEnemySpawned?.Invoke();
            }

            _currentWave = null;
        }
    }

    private int GetRandomePointSpawn()
    {
        _pointNumber = Random.Range(0, _spawnPoints.Length);

        return _pointNumber;
    }

    private void InstantiateEnemy()
    {
        Enemy enemy = Instantiate(_currentWave.Template, _spawnPoints[_pointNumber].position, _spawnPoints[_pointNumber].rotation, _spawnPoints[_pointNumber]).GetComponent<Enemy>();
        enemy.Init(_player);
        enemy.EnemyDied += EnemyDying;
    }

    private void SetWave(int index)
    {
        _currentWave = _waves[index];
    }

    public void NextWave()
    {
        SetWave(++_currentWaveNumber);
        _spawned = 0;
    }

    private void EnemyDying(Enemy enemy)
    {
        enemy.EnemyDied -= EnemyDying;
    }
}

[System.Serializable]

public class Wave
{
    public GameObject Template;
    public float Delay;
    public int Count;
}
