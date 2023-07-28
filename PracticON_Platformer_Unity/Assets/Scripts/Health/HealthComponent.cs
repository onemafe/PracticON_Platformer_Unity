using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour
{   
    [SerializeField] private int _health;
    [SerializeField] private int _maxHealth;

    [SerializeField] private UnityEvent _onDamage;
    [SerializeField] public UnityEvent _onDie;
    [SerializeField] private UnityEvent _onHeal;

    private GameSession gameSession;
    private HealthUI healthUI;


    private void Start()
    {
        if (gameObject.CompareTag("Player"))
        {
            gameSession = GameObject.Find("GameSession").GetComponent<GameSession>();
            healthUI = GameObject.Find("HealthUI").GetComponent<HealthUI>();
        }

    }

    [ContextMenu("Kill")]
    public void Kill()
    {
        ChangeHealth(-_health);
    }



    public void ChangeHealth(int _changeHPValue)
    {
        if (_health <= 0) return;

        _health += _changeHPValue;
        _health = Mathf.Min(_health, _maxHealth); // проверка чтобы жизни не были больше максимального

        if (_changeHPValue < 0)
            _onDamage?.Invoke();

        if (_changeHPValue >= 0)
            _onHeal?.Invoke();

        if (_health <= 0)
            _onDie?.Invoke();


        if (gameObject.CompareTag("Player"))
        {
            gameSession.Health = _health;
            healthUI.DisplayHealth(_health);
        }


        print("HP:" + _health);
    }





    //Методы вызываемые из Player, и жизни игрока из Player придут, а не отсюда
    public void SetHealth(int health) 
    {
        _health = health;
    }

    public void SetMaxHealth(int maxHealth) 
    {
        _maxHealth = maxHealth;
    }


    private void OnDestroy()
    {
        _onDie.RemoveAllListeners();
    }
}



