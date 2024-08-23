using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class mover : MonoBehaviour
{   
        private Rigidbody rb;
        [SerializeField] 
        private float movementSpeed, coefficient;

        [SerializeField]
        private float Time;

        [SerializeField]
        private LayerMask WhatIsGround;

        [SerializeField]
        private AnimationCurve animCurve;

        



    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Ichigo needs to kill those hollows !");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate() 
    {  
       Movement();    
    }

    void Update() 
    {  
      SurfaceAlignement();  
    }

    private void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(x, 0, y);
        Vector3 counterMovement = new Vector3(-rb.velocity.x, 0, -rb.velocity.z);
    
        rb.AddForce(movement * movementSpeed ); 
        rb.AddForce(counterMovement * coefficient);   
    }
    private void SurfaceAlignement()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit info = new RaycastHit();
        Quaternion RotationRef = Quaternion.Euler(0,0,0);
        
        if (Physics.Raycast(ray, out info, WhatIsGround))
        {
            RotationRef = Quaternion.Lerp(transform.rotation, Quaternion.FromToRotation(Vector3.up, info.normal), animCurve.Evaluate(Time));
            transform.rotation = Quaternion.Euler(RotationRef.eulerAngles.x, transform.eulerAngles.y, RotationRef.eulerAngles.z);
        }
    }
}
