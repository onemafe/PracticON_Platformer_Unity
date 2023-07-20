
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Events;

public class EnterTriggerChangeHero : MonoBehaviour
{

    private GameObject go;
    [SerializeField] private SpawnComponent _spawn;
    [SerializeField] private CinemachineVirtualCamera _vcam;
    [SerializeField] GameObject _prefabTarget;


    //Collider нужно держать в комплекте с префабом
    private void OnTriggerEnter(Collider other)
    {
        go = other.gameObject.transform.parent.gameObject;
        Destroy(go);
        _spawn.Spawn();

        /*_vcam.Follow = _prefabTarget.transform;
        _vcam.LookAt = _prefabTarget.transform;*/

    }

}


