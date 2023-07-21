using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnterTriggerComponent : MonoBehaviour
{

    [SerializeField] private  EnterEvent _action;
    private void OnTriggerEnter2D(Collider2D other)
    {
        _action?.Invoke(other.gameObject);

    }
}
