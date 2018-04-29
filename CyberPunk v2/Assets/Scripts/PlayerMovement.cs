using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed;
    //public Rigidbody rb;
    public float jumpForce;
    public CharacterController controller;
    private Vector3 moveDirection;
    public float gravityScale;

    public Animator anim;

	// Use this for initialization
	void Start () {
        //rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
       moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y , Input.GetAxis("Vertical") * moveSpeed);


        if (controller.isGrounded)
        {
            moveDirection.y = 0f;
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);

        controller.Move(moveDirection * Time.deltaTime);

        anim.SetBool("isGrounded", controller.isGrounded);

        anim.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))));
    }
    
}
