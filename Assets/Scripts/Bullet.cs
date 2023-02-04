using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _timeLifeBullet;

    public float Damage => _damage;
    
    private void Awake()
    {
        Destroy(gameObject, _timeLifeBullet);
    }
}
