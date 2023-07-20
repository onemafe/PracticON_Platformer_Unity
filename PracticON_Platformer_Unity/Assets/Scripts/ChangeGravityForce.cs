using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGravityForce : MonoBehaviour
{
    private ConstantForce constForce;
    private GameObject go;
    [SerializeField] private float yForce;

    private void OnCollisionEnter(Collision other)
    {
        go = other.gameObject;
        constForce = go.GetComponent<ConstantForce>();
        constForce.force = new Vector3(0,yForce,0);
    }
}
