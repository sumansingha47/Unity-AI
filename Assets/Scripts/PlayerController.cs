using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float rotationSpeed = 100f;
    // [SerializeField] float forcePower = 100f;



    void Update()
    {
        PlayerMovement();
        RotationOfPlayer();
    }


    void PlayerMovement()
    {
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");
        if(moveVertical != 0)
        {

            Vector3 movePlayerV = new Vector3(0, 0, moveVertical);
            transform.Translate(movePlayerV * Time.deltaTime * movementSpeed);
        }
        else if(moveHorizontal != 0)
        {
            Vector3 movePlayerH = new Vector3(moveHorizontal, 0, 0);
            transform.Translate(movePlayerH * Time.deltaTime * movementSpeed);
        }
              
    }

    void RotationOfPlayer()
    {
        if(Input.GetKey(KeyCode.C))
        {
            transform.Rotate(1f * Time.deltaTime * rotationSpeed, 0, 0);
        }
        else if(Input.GetKey(KeyCode.X))
        {
            transform.Rotate(1f * Time.deltaTime * -rotationSpeed, 0, 0);
        }
        
    }

    // void addForceToPlayer()
    // {
    //     if(Input.GetKey(KeyCode.Space))
    //     {
    //         rb.AddRelativeForce(Vector3.up *Time.deltaTime * forcePower);
    //     }
        
    // }

}