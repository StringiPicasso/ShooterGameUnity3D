using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private ParticleSystem _muzzleFlash;
    [SerializeField] private Transform _bulletSpawn;
    [SerializeField] private AudioClip _clip;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _speed;


    private Rigidbody _bulletRigidbody;
    private Bullet _currentBullet;

    public void Shoot()
    {
        _audioSource.PlayOneShot(_clip);
        _muzzleFlash.Play();

        _currentBullet=Instantiate(_bullet, _bulletSpawn.position, _bulletSpawn.rotation);
        _bulletRigidbody = _currentBullet.GetComponent<Rigidbody>();
        _bulletRigidbody.AddForce(_bulletSpawn.forward * _speed, ForceMode.Impulse);
    }
}
