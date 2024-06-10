using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public float movementSpeed = 10f;
   public float rotationSpeed = 100f;
   [SerializeField] float forcePower = 1000f;
   [SerializeField] float jumpForce = 10f;
   bool isGrounded = false;

   Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
        rotatePlayer();
        addForceToPlayer();
        JumpPlayer();   
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void movePlayer()
    {
        float getAxisZ = Input.GetAxis("Vertical");
        if(getAxisZ != 0)
        {
            Vector3 movement = new Vector3(0, 0, getAxisZ);
            transform.Translate(movement * movementSpeed * Time.deltaTime);
        }
    }

    void rotatePlayer()
    {
        float getAxisX = Input.GetAxis("Horizontal");
        if(getAxisX != 0)
        {
            transform.Rotate(0, getAxisX * rotationSpeed * Time.deltaTime, 0);
        }
    }

    void addForceToPlayer()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            Vector3 forceVector = new Vector3(0, 1f, 0);
            rb.AddRelativeForce(forceVector * forcePower * Time.deltaTime);
        }
    }

    void JumpPlayer()
    {
        if(isGrounded == true && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}