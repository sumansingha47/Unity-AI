using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float rotationSpeed = 100f;
    // [SerializeField] float forcePower = 100f;



    void Update()
    {
        MovePlayer();
        RotationOfPlayer();
    }


    void MovePlayer()
    {
        float moveVertical = Input.GetAxis("Vertical");
        
        if(moveVertical != 0)
        {

            Vector3 movePlayerV = new Vector3(0, 0, moveVertical);
            transform.Translate(movePlayerV * Time.deltaTime * movementSpeed);
        }
                      
    }

    void RotationOfPlayer()
    {
        if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 1f * Time.deltaTime * rotationSpeed, 0);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 1f * Time.deltaTime * -rotationSpeed, 0);
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