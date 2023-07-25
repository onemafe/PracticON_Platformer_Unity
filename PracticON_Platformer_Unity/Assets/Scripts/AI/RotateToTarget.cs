using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToTarget : MonoBehaviour
{
    [SerializeField] private Vector3 leftEuler;
    [SerializeField] private Vector3 rightEuler;
    private Vector3 _targetEuler;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private bool toLeft;

    private void Start()
    {
        if(toLeft)
        {
            _targetEuler = leftEuler;
        }
        else
        {
            _targetEuler = rightEuler;
        }
    }

    void Update()
    {
        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(_targetEuler), Time.deltaTime * rotationSpeed);
    }

    public void ReturnToLeft()
    {
        _targetEuler = leftEuler;
    }
    public void ReturnToRight()
    {
        _targetEuler = rightEuler;
    }
}
