using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PatrolState : State
{
    private const string Walking = "Walking";

    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _patrolPoints;

    private Animator _animator;

    private int _pointNumber=0;
    private float _range = 0.5f;

    private void Awake()
    {
      _animator=GetComponent<Animator>();
    }

    private void Update()
    {
        MoveInPatrol();
    }

    private void Move()
    {
        _animator.Play(Walking);

        transform.LookAt(_patrolPoints[_pointNumber].position);
        transform.position = Vector3.MoveTowards(transform.position, _patrolPoints[_pointNumber].position, _speed * Time.deltaTime);
    }

    private void MoveInPatrol()
    {
        if (Vector3.Distance(transform.position, _patrolPoints[_pointNumber].position) > _range)
        {
            Move();
        }
        else
        {
            _pointNumber = Random.Range(0, _patrolPoints.Length);
        }
    }
}
