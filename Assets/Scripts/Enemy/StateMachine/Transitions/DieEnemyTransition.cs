using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieEnemyTransition : Transition
{
    [SerializeField] private Enemy _enemy;

    private void Update()
    {
        if (_enemy.Health <= 0)
        {
            NeedTransit = true;
        }
    }
}
