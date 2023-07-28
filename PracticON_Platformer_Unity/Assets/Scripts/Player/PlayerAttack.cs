using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private Animator _animator;
    [SerializeField] private Collider _weaponCollider;



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Hit();
        }
    }
    private void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }



    private void Hit()
    {
        _animator.SetTrigger("melee");
    }

    public void EnableWeaponCollider()
    {
        _weaponCollider.enabled = true;
    }

    public void DisableWeaponCollider()
    {
        _weaponCollider.enabled = false;
    }





    
}
