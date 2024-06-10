using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator myAnim;

    public bool isRunning = false;
    public bool isRunBack = false;
    public bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isRunning = Input.GetKey(KeyCode.W);
        isRunBack = Input.GetKey(KeyCode.S);
        isJumping = Input.GetKey(KeyCode.Space);

        myAnim.SetBool("isRunning", isRunning);
        myAnim.SetBool("isRunBack", isRunBack);
        myAnim.SetBool("isJumping", isJumping);

        if(Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = false;
            isRunBack = false;
            isJumping = false;
        }
    }
}
