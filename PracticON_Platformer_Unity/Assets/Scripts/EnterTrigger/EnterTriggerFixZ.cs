
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Events;

public class EnterTriggerFixZ : MonoBehaviour
{

    private Rigidbody rb;



    //Collider нужно держать в комплекте с префабом
    private void OnTriggerEnter(Collider other)
    {
        rb = other.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
    }

}


