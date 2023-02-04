using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleHealth : MonoBehaviour
{
    [SerializeField] private float _healCount;
    [SerializeField] private Player _player;

    public void Cure()
    {
        _player.Heal(_healCount);
    }
}
