using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class WaitingEnemyHelperState : State
{
    private const string Waiting = "Waiting";

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _animator.Play(Waiting);
    }

    private void OnDisable()
    {
        _animator.StopPlayback();
    }
}
