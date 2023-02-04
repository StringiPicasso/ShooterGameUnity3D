using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class AttackState : State
{
    private const string Attack = "Attack";

    [SerializeField] private Weapon _weapon;
    [SerializeField] private float _delay;
    [SerializeField] private float _speedMove;
    [SerializeField] private float _rangeMove;

    private Animator _animator;
    private float _lastAttackTime;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _weapon.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        _weapon.gameObject.SetActive(false);
        _animator.StopPlayback();
    }

    private void Update()
    {
        Pursue();
        Fire();
    }

    private void Fire()
    {
        _animator.Play(Attack);

        if (_lastAttackTime <= 0)
        {
            _weapon.Shoot();
            _lastAttackTime = _delay;
        }

        _lastAttackTime -= Time.deltaTime;
    }

    private void Pursue()
    {
        transform.LookAt(new Vector3(Target.transform.position.x,0,Target.transform.position.z));
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(Target.transform.position.x,0,Target.transform.position.z), _speedMove * Time.deltaTime);
    }
}