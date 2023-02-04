using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallHelperBoss : MonoBehaviour
{
    [SerializeField] private EnemySpawner _currentState;
    [SerializeField] private Enemy _enemy;

    private void OnEnable()
    {
        _enemy.EnemyHelped += OnEnemyHelped;
    }

    private void OnDisable()
    {
        _enemy.EnemyHelped -= OnEnemyHelped;
    }

    private void OnEnemyHelped()
    {
        _currentState.enabled=true;
    }
}
