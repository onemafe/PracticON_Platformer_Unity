using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPlayer : MonoBehaviour
{
    private Transform _playerTransform;
    private Transform _thisTransform;


    private void Start()
    {
        _playerTransform = PlayerMovement.Instance.transform;
    }

    void Update()
    {
        transform.LookAt(new Vector3(_playerTransform.position.x, transform.position.y, _playerTransform.position.z));
    }

}
