using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private HealthUI _healthUI;
    [SerializeField] private GameSession gameSession;
    void Start()
    {
        var health = GetComponent<HealthComponent>();

        health.SetHealth(gameSession.Health);
        health.SetMaxHealth(gameSession.MaxHealth);

        _healthUI.Setup(gameSession.MaxHealth);
        _healthUI.DisplayHealth(gameSession.Health);
    }




}
