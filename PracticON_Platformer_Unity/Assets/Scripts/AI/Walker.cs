using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Direction
{
    Left,
    Right
}

public class Walker : MonoBehaviour
{
    [SerializeField] private Transform leftTarget;
    [SerializeField] private Transform rightTarget;

    [SerializeField] private float speed;
    [SerializeField] private float stopTime;
    private bool isStopped;

    [SerializeField] private Direction currentDirection;

    public UnityEvent EventOnLeftTarget;
    public UnityEvent EventOnRightTarget;



    // Start is called before the first frame update
    void Start()
    {
        leftTarget.parent = null;
        rightTarget.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStopped == true)
        {
            return;
        }

        if (currentDirection == Direction.Left)
        {
            transform.position -= new Vector3(Time.deltaTime * speed, 0f, 0f);
            if (transform.position.x < leftTarget.position.x)
            {
                currentDirection = Direction.Right;
                isStopped = true;
                Invoke(nameof(ContinueWalk), stopTime);
                EventOnLeftTarget.Invoke();

            }
        }
        if (currentDirection == Direction.Right)
        {
            transform.position += new Vector3(Time.deltaTime * speed, 0f, 0f);
            if (transform.position.x > rightTarget.position.x)
            {
                currentDirection = Direction.Left;
                isStopped = true;
                Invoke(nameof(ContinueWalk), stopTime);
                EventOnRightTarget.Invoke();

            }
        }
    }
    private void ContinueWalk()
    {
        isStopped = false;
    }
}
