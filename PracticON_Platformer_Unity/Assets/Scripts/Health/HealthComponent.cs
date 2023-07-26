using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] public int _health;
    [SerializeField] private UnityEvent _onDamage;
    [SerializeField] public UnityEvent _onDie;
    [SerializeField] private UnityEvent _onHeal;



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



    public void SetHealth(int health) //В классе Hero обращаемся к этому методу чтобы установить жизни. Там они берутся из Gamesession.
    {
        _health = health;
    }


    //что это?
    private void OnDestroy()
    {
        _onDie.RemoveAllListeners();
    }
}



