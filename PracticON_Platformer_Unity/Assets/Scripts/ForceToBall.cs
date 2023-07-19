using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceToBall : MonoBehaviour
{
    [SerializeField] private Vector3 _direction;
    [SerializeField] private float _force;

    private Rigidbody _rb;
    
    

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.AddForce(_direction, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
