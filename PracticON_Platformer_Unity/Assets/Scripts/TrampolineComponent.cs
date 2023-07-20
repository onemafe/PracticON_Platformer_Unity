using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineComponent : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject go;
    [SerializeField] private float yForce;

    private void OnCollisionEnter(Collision other)
    {
        go = other.gameObject;
        rb = go.GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0, yForce, 0),ForceMode.Impulse);
    }
}
