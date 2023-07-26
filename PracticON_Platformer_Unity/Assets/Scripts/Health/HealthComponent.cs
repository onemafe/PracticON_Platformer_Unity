using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour
{   
    private int _health;
    private int _maxHealth;

    [SerializeField] private UnityEvent _onDamage;
    [SerializeField] public UnityEvent _onDie;
    [SerializeField] private UnityEvent _onHeal;

    [SerializeField] private HealthUI _healthUI;

    [ContextMenu("Kill")]
    public void Kill()
    {
        ChangeHealth(-_health);
    }



    public void ChangeHealth(int _changeHPValue)
    {
        if (_health <= 0) return;

        _health += _changeHPValue;

        if (_changeHPValue < 0)
            _onDamage?.Invoke();

        if (_changeHPValue >= 0)
            _onHeal?.Invoke();

        if (_health <= 0)
            _onDie?.Invoke();


        print("HP:" + _health);
    }



    public void SetHealth(int health) 
    {
        _health = health;
    }

    public void SetMaxHealth(int maxHealth) 
    {
        _maxHealth = maxHealth;
    }


    //что это?
    private void OnDestroy()
    {
        _onDie.RemoveAllListeners();
    }
}



