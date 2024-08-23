using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalMover : MonoBehaviour
{

    public float moveSpeed = 0.04f;
    public float strafeSpeed = 0.04f;

    public float horizontal;
    public float vertical;

    public Vector3 move;

    public CharacterController playerController;
    
    void Awake()
    {
        playerController = GetComponent<CharacterController>();
    }

    void LateUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        move = new Vector3(horizontal, 0, vertical);
        playerController.Move(move * Time.deltaTime * moveSpeed);

        if (Input.GetKey(KeyCode.W) )
        {
            playerController.Move(transform.TransformDirection(Vector3.forward) * moveSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerController.Move(transform.TransformDirection(Vector3.back) * moveSpeed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            playerController.Move(transform.TransformDirection(Vector3.left) * strafeSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            playerController.Move(transform.TransformDirection(Vector3.right) * strafeSpeed);
        }
    }
}
