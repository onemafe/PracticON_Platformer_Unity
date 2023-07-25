using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float _moveSpeed = 3;
    [SerializeField] private float _jumpForce = 10;
    [SerializeField] private float _friction = 0.6f;
    [SerializeField] private float _maxSpeed = 5;

    [SerializeField] private float _rotationSpeed;

    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private Animator _animator;

    private float coyoteTime = 0.2f; //Чем выше это значение, тем дольше игрок может прыгать после отрыва от земли
    private float coyoteTimeCounter; //Счётчик времени кайота

    private float jumpBufferTime = 0.2f; //Сколько действует буффер
    private float jumpBufferCounter; //Счётчик времени буффера

    private float jumpFramesTimer;

    private float _xAxis;
    private float _xEuler = 90;
    private bool _isGrounded = false;







    //Проверка isGrounded
    private void OnCollisionStay(Collision collision)
    {
        for (int i = 0; i < collision.contactCount; i++)
        {
            float angle = Vector3.Angle(collision.contacts[i].normal, Vector3.up);
            if(angle < 45f)
            {
                _isGrounded = true;
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        _isGrounded = false;
    }


    //Нужны пояснения
    private void Update()
    {
        _xAxis = Input.GetAxisRaw("Horizontal"); //Возвращает 1 -1

        jumpFramesTimer += Time.deltaTime; //считается таймер для багов


        // даётся время для прыжка койота. мы уже не grounded, но прыгнуть сможем, пока время убавляется в deltaTime
        if (_isGrounded)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }


        //Возмодность отпрыгнуть, когда нажали прыжок во время прыжка
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }


        if (coyoteTimeCounter > 0 && jumpBufferCounter > 0 && jumpFramesTimer > 0.4f)
        {
            jumpFramesTimer = 0;
            jumpBufferCounter = 0;
            Jump();
        }

        //Если отпустили Space
        if(Input.GetKeyUp(KeyCode.Space) && _rigidBody.velocity.x > 0f)
        {
            coyoteTimeCounter = 0f;
        }

        //Поворот
        
        if (_xAxis > 0)
            _xEuler = 90f;
        if (_xAxis < 0)
            _xEuler = -90f;
        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0, _xEuler, 0), Time.deltaTime * _rotationSpeed);


        _animator.SetBool("isRunning", Input.GetAxis("Horizontal") != 0);
    }



    private void Jump()
    {
        _animator.SetTrigger("jump");
        _rigidBody.AddForce(0, _jumpForce, 0, ForceMode.VelocityChange);
        Debug.Log("Прыжок");
    }


    private void FixedUpdate()
    {
        float input = Input.GetAxis("Horizontal");
        float speedMultiplierInAir = 1f;

        if(_isGrounded)
        {
            _rigidBody.AddForce(input * _moveSpeed, 0, 0, ForceMode.VelocityChange);
        }
        else
        {
            speedMultiplierInAir = 0.2f;

            if (_rigidBody.velocity.x > _maxSpeed && input > 0)
                speedMultiplierInAir = 0;
            if (_rigidBody.velocity.x < -_maxSpeed && input < 0)
                speedMultiplierInAir = 0;
            _rigidBody.AddForce(input * _moveSpeed * speedMultiplierInAir, 0, 0, ForceMode.VelocityChange);
        }

        //трение по оси x добавляем, чтобы не ускоряться бесконечно. В воздухе оно становится в 0.2 раза меньше, по z ускорение для Girl
        _rigidBody.AddForce(-_rigidBody.velocity.x * _friction * speedMultiplierInAir, 0, -_rigidBody.velocity.z * _friction/2, ForceMode.VelocityChange);
    }



    
}
