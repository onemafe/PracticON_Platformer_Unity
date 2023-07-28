using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BulletCreator : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float speed;

    private Transform _playerTransform;

    private Rigidbody _rigidBody;



    private void Create()
    {
        var instantiate = Instantiate(_prefab, _target.position, Quaternion.identity);

        _rigidBody = instantiate.GetComponent<Rigidbody>();

        Transform playerTransform = PlayerMovement.Instance.transform;
        Vector3 toPlayer = (playerTransform.position - transform.position);

        _rigidBody.velocity = toPlayer;

    }
}
