using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1;
    [SerializeField] float jumpForce = 8;
    bool grounded = true;

    Vector3 movementVector;

    Rigidbody rb;

    [SerializeField] Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", movementVector.magnitude);

    }

    private void FixedUpdate()
    {
        if (movementVector.magnitude > 0.1){
            rb.AddForce(movementVector * moveSpeed, ForceMode.Acceleration);
        }
        
        else{
            Vector3 currentVelocity = rb.linearVelocity;
            Vector3 targetVelocity = new Vector3(0f, currentVelocity.y, 0f);
            rb.linearVelocity = Vector3.Lerp(currentVelocity, targetVelocity, 0.2f);
        }


        if(isGrounded()){
            grounded = true;
            animator.SetBool("Jump", false);
            animator.SetBool("Grounded", true);
        }
        else{
            grounded = false;
            animator.SetBool("Grounded", false);
        }
    }

    bool isGrounded(){
        bool hit = Physics.Raycast(transform.position, Vector3.down, 1.1f);
        return hit;
    }

    public void OnJump()
    {
        if (grounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetBool("Jump", true);
        }
    }
    public void OnMove(InputValue v)
    {
        Vector2 inputVector = v.Get<Vector2>();
        movementVector = new Vector3(inputVector.x, 0, inputVector.y);
        
        transform.forward = movementVector.normalized;
    }
}
