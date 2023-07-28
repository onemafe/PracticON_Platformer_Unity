using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnterTriggerComponent : MonoBehaviour
{
    [SerializeField] private string _tag;
    [SerializeField] private  EnterEvent _action;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(_tag))
        {
            _action?.Invoke(other.gameObject);
            Debug.Log("Player");
        }


    }
}
