using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Slider _slider;

    private void OnEnable()
    {
        _enemy.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _enemy.HealthChanged -= OnHealthChanged;
    }

    private void Start()
    {
        _slider.maxValue = _enemy.Health;
        _slider.value = _enemy.Health;
    }

    public void OnHealthChanged(float target)
    {
        _slider.value=_enemy.Health;
    }
}
