using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isRunningHash;
    int isBlockingHash;
    bool alreadyequipped;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        isBlockingHash = Animator.StringToHash("isBlocking");
        
        alreadyequipped = false;
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);

        bool forwardPressed = Input.GetKey("w");
        bool leftPressed = Input.GetKey("a");
        bool rightPressed = Input.GetKey("d");
        bool backPressed = Input.GetKey("s");
        bool runPressed = Input.GetKey("left shift");
        bool jumpPressed = Input.GetKeyDown("space");
        bool equipPrimaryWeaponPressed = Input.GetKeyDown("r");
        bool blockPressed = Input.GetKeyDown("mouse 1");  // Changed to GetKey to detect held state
        bool blockReleased = Input.GetKeyUp("mouse 1");
        bool attackPressed = Input.GetKeyDown("mouse 0");
        bool crouchPressed = Input.GetKeyDown("left ctrl");
        bool crouchReleased = Input.GetKeyUp("left ctrl");
        animator.SetInteger("random", Random.Range(0, 9));

        if (!isWalking && (forwardPressed || leftPressed || rightPressed || backPressed))
        {
            animator.SetBool(isWalkingHash, true);
        }

        if (isWalking && (!forwardPressed && !leftPressed && !rightPressed && !backPressed))
        {
            animator.SetBool(isWalkingHash, false);
        }

        if (!isRunning && ((forwardPressed || leftPressed || rightPressed || backPressed) && runPressed))
        {
            animator.SetBool(isRunningHash, true);
        }

        if (isRunning && (!runPressed || (!forwardPressed && !leftPressed && !rightPressed && !backPressed)))
        {
            animator.SetBool(isRunningHash, false);
        }

        if (equipPrimaryWeaponPressed)
        {
            if (!alreadyequipped)
            {
                animator.SetTrigger("drawSword");
                Debug.Log("equipping primary weapon");
                alreadyequipped = true;
                animator.SetBool("swordEquiped", true);
            }
            else
            {
                animator.SetTrigger("drawBackSword");
                Debug.Log("sheathing primary weapon");
                alreadyequipped = false;
                animator.SetBool("swordEquiped", false);

            }
        }

        if (alreadyequipped && attackPressed)
        {
            animator.SetTrigger("attack");
            Debug.Log("attacking");
        }

        if (alreadyequipped && blockPressed)
        {
            animator.SetBool(isBlockingHash, true);
            Debug.Log("blocking");
        }

        if (alreadyequipped && blockReleased)
        {
            animator.SetBool(isBlockingHash, false);
            Debug.Log("stopped blocking");
        }

        if (crouchPressed)
        {
            animator.SetBool("isCrouching", true);
            Debug.Log("crouching");
        }

        if (crouchReleased)
        {
            animator.SetBool("isCrouching", false);
            Debug.Log("stopped crouching");
        }



        if (!isRunning && !isWalking && jumpPressed)
        {
            animator.SetTrigger("Jump");
            Debug.Log("jumping");
        }

        /*
        if (!isRunning && isWalking && jumpPressed)
        {
            animator.SetTrigger("SmallJump");
            Debug.Log("jumping while walking");
        }
        */

        if (isRunning && jumpPressed)
        {
            animator.SetTrigger("BigJump");
            Debug.Log("jumping while running");
        }
    }
}


