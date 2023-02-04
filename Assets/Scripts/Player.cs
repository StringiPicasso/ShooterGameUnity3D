using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, IDamageable, IHealeable
{
    private const string GameOverScene = "GameOverScene";

    [SerializeField] private List<BottleHealth> _healFlaskCounts;
    [SerializeField] private float _health;
    [SerializeField] private float _dangerousHealth;
    [SerializeField] private Weapon _currentWeapon;
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private TMP_Text _flaskHealthCountText;
    [SerializeField] private Image _bloodScreen;

    private BottleHealth _currentFlaskHealth;
    private float _currentHealth;
    private float _currentFlaskHealthCount;
    private int _healFlaskNumber = 0;

    private void Start()
    {
        _currentHealth = _health;
        _currentFlaskHealth = _healFlaskCounts[_healFlaskNumber];
        _currentFlaskHealthCount = _healFlaskCounts.Count;
    }
    
    private void Update()
    {
        _healthText.text = _currentHealth.ToString();
        _flaskHealthCountText.text = _currentFlaskHealthCount.ToString();

        if (Input.GetMouseButtonDown(0))
        {
            _currentWeapon.Shoot();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
           TryGetHealing();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Bullet bullet))
        {
            Damage(bullet.Damage);
        }
    }

    private void TryGetHealing()
    {
        if (_healFlaskCounts.Count > 0 &&_currentHealth!=_health)
        {
            _currentFlaskHealth.Cure();
        }
    }

    public void TakeHeal(float healValue)
    {
        _currentHealth += healValue;

        if (_currentHealth > _health)
        {
            _currentHealth = _health;
        }
        
        _healFlaskCounts.RemoveAt(_healFlaskNumber);
        _currentFlaskHealthCount = _healFlaskCounts.Count;
    }

    public void ApplyDamage(float damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            SceneManager.LoadScene(GameOverScene);
        }

        if (_currentHealth <= _dangerousHealth)
        {
            _bloodScreen.gameObject.SetActive(true);
        }
        else
        {
            _bloodScreen.gameObject.SetActive(false);
        }
    }

    public void Damage(float damage)
    {
        ApplyDamage(damage);
    }

    public void Heal(float healCount)
    {
        TakeHeal(healCount);
    }
}
