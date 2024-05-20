using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour, ITakeDamage
{
    public float HealthPoints => _currentHealth;
    private float _currentHealth;
    public float MaxHealthPoints = 100;

    public event Action PlayerDie;

    void Start()
    {
        _currentHealth = 100;
    }

    public void TakeDamage(float amount)
    {
        _currentHealth -= amount;
        if (_currentHealth <= 0)
        {
            Die();
        }
        Debug.Log("Health reduced by: " + amount + ". Current health: " + HealthPoints);
    }

    private void Die()
    {
        PlayerDie?.Invoke();
    }

    private void OnEnable()
    {
        PlayerDie += Death;
    }

    private void OnDisable()
    {
        PlayerDie -= Death;
    }

    private void Death()
    {
        Invoke("DestroyObject", 1.0f);
        Debug.Log("Player has died");
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
    public void Heal(float amount)
    {
        _currentHealth += amount;
        Debug.Log("Health restored by: " + amount + ". Current health: " + HealthPoints);
    }
}
