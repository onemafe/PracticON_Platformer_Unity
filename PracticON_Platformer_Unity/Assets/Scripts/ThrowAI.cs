using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowAI : MonoBehaviour
{
    [SerializeField] private SpawnComponent _spawn;
    [SerializeField] private float _delay;
    [SerializeField] private float _repeat;



    private void Start()
    {
        _spawn = GetComponent<SpawnComponent>();
        InvokeRepeating("OnSpawnProjectile", _delay, _repeat);

    }

    private void Update()
    {

    }


    private void OnSpawnProjectile()
    {
        _spawn.Spawn();
    }

}
