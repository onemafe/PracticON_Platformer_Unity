
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Events;

public class EnterTriggerChangeHero : MonoBehaviour
{

    [SerializeField] private GameObject _goEnable;
    private GameObject _goDisable;
    [SerializeField] private CinemachineVirtualCamera _vcam;



    //Collider нужно держать в комплекте с префабом
    private void OnTriggerEnter(Collider other)
    {
        _goDisable = other.gameObject;
        _goDisable.SetActive(false);
        _goEnable.SetActive(true);

        _vcam.Follow = _goEnable.transform;
        _vcam.LookAt = _goEnable.transform;

    }

}


