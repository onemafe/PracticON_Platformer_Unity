
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnterTriggerChangeHero : MonoBehaviour
{

    private GameObject go;
    [SerializeField] private SpawnComponent _spawn;


    //Collider нужно держать в комплекте с префабом
    private void OnTriggerEnter(Collider other)
    {
        go = other.gameObject.transform.parent.gameObject;
        Destroy(go);
        _spawn.Spawn();
    }

}

//animator.runtimeAnimatorController = Resources.Load(“path_to_your_controller”) 


