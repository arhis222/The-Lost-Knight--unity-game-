using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverSimple : MonoBehaviour
{   
    //[SerializeField] float xValue = 0;
    [SerializeField] float yValue = 0f;
    //[SerializeField] float zValue = 0;
    [SerializeField] float moveSpeed = 1f;
    



    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Ichigo needs to kill those hollows !");

    }

    // Update is called once per frame
    void Update() 
    {  
       float horizontalInput = Input.GetAxis("Horizontal");
       float verticalInput = Input.GetAxis("Vertical"); 
        
       
       

       Vector3 movementDirection = new Vector3(horizontalInput, yValue, verticalInput);

       // The Normalize() method adjusts the length of a vector to 1 while preserving its direction.
       // This is useful when only the direction of a vector is important, and the length can be disregarded. 
       movementDirection.Normalize(); 
       // This line of code moves an object (typically in a Unity game) in a specific direction.
       // The transform.Translate() method is used to change the position of an object.
       // Here, the expression movementDirection * Time.deltaTime * moveSpeed determines the direction and speed of movement.
       // - movementDirection: This is a vector indicating the direction in which the object wants to move.
       // - Time.deltaTime: Represents the time it takes for one frame of the game loop to execute.
       //   It ensures consistent movement speed across different devices.
       // - moveSpeed: Determines how fast the object moves.
       // As a result, the movementDirection vector specifies the direction in which the object wants to move.
       // It's multiplied by Time.deltaTime and moveSpeed to calculate how far the object should move in each frame of the game loop.
       // The Space.World argument indicates that this movement should be in world coordinates,
       // meaning the object moves in the specified direction relative to the world axes.

       transform.Translate(movementDirection * Time.deltaTime * moveSpeed,Space.World);
       
       // If movementDirection is not zero, the object's forward direction (transform.forward) is set to match the movementDirection vector.
       // Here, transform.forward represents the forward vector of the object in world coordinates, indicating its direction of movement.
       if (movementDirection != Vector3.zero)
       {
            transform.forward = movementDirection;
       }
    }
}
