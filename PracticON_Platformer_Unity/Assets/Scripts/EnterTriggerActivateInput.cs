
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Events;

public class EnterTriggerActivateInput : MonoBehaviour
{

    [SerializeField] private PlayerMovement _movementComponent;
    [SerializeField] private bool _bool;



    //Collider нужно держать в комплекте с префабом
    private void OnTriggerEnter(Collider other)
    {
        _movementComponent.enabled = _bool;
    }

}


