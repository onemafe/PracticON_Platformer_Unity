using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowAI : MonoBehaviour
{
    [SerializeField] private SpawnComponent _spawn;
    [SerializeField] private float _delay;
    [SerializeField] private float _repeat;
    [SerializeField] private Vector3 _direction;
    private ForceToBall _prefabBall;



    private void Start()
    {
        InvokeRepeating("OnSpawnProjectile", _delay, _repeat);
    }




    private void OnSpawnProjectile()
    {
        _spawn.Spawn();
        _spawn = GetComponent<SpawnComponent>();
        _prefabBall = _spawn.Prefab.GetComponent<ForceToBall>();
        _prefabBall._direction = _direction;
    }

}
