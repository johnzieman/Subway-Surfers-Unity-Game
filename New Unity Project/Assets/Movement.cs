using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Animator animator;
    private Rigidbody characterController;


    private bool isInMovement = false;

    public float distance = 3f;
    private float time = 2.067f;
    private float currentDistance = 0f;
    private float currentDirection = 0f;


    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float dir = Input.GetAxisRaw("Horizontal");
        if (dir != 0 && isInMovement == false)
        {

            isInMovement = true;
            currentDirection = dir;
            currentDistance = distance;

            if (dir > 0)
            {
                animator.SetTrigger("Right");
            }
            if (dir < 0)
            {
                animator.SetTrigger("Left");
            }
        }

        if (isInMovement)
        {
            move();
        }
    }

    private void move()
    {
        if (currentDistance <= 0)
        {
            isInMovement = false;
            return;
        }

        float speed = distance / time;
        float tmpDistance = Time.deltaTime * speed;
        characterController.AddForce(Vector3.right * currentDirection * tmpDistance);
        currentDistance -= tmpDistance;
    }
}
