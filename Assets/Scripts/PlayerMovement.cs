using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float speedRotation;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {        
        
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();


        if (horizontalInput > 0.2 || horizontalInput < -0.2 || verticalInput > 0.2 || verticalInput < -0.2)
        {
            transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);
        }
        
        if (movementDirection != Vector3.zero)
        {
            animator.SetBool("IsMoving", true);

            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, speedRotation * Time.deltaTime);
        } else
        {

            animator.SetBool("IsMoving", false);
        }
    }
}
