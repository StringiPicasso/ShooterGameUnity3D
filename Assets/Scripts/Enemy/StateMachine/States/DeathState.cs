using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class DeathState : State
{
    private const string IsDeath = "IsDeath";
    private const string Death = "Death";

    [SerializeField] private float _timeDeathEnemy;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _animator.GetBool(IsDeath);
        _animator.SetBool(IsDeath, true);
        _animator.Play(Death);
        DeathEnemy();
    }

    private void DeathEnemy()
    {
        _timeDeathEnemy=_animator.GetCurrentAnimatorStateInfo(0).length+_timeDeathEnemy;
        Destroy(gameObject, _timeDeathEnemy);
    }
}
