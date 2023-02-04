using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private float _health;
    [SerializeField] private Player _target;
    [SerializeField] private float _gangerousHealthEnemy;

    public event UnityAction<float> HealthChanged;
    public event UnityAction<Enemy> EnemyDied;
    public event UnityAction EnemyHelped;

    public Player Target => _target;
    public float Health => _health;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Bullet bullet))
        {
            Damage(bullet.Damage);
        }
    }

    public void Init(Player target)
    {
        _target = target;
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(Health);

        if (Health <= _gangerousHealthEnemy)
        {
            EnemyHelped?.Invoke();
        }
    }

    public void Damage(float damage)
    {
        TakeDamage(damage);
    }
}