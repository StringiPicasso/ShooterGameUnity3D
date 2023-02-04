using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class WaitingStateBoss : State
{
    private const string Dance = "Dance";

    [SerializeField] private AudioClip _clip;
    [SerializeField] private AudioSource _audioSource;
    
    private Animator _animator;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _audioSource.PlayOneShot(_clip);
        _animator.Play(Dance);
    }

    private void OnDisable()
    {
        _animator.StopPlayback();
    }
}

