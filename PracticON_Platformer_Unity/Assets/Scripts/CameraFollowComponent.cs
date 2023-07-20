using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowComponent : MonoBehaviour
{

    [SerializeField] public GameObject _target;
    void Update()
    {
        transform.position = _target.transform.position;
    }
}
