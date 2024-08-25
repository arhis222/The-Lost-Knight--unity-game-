using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doormovements : MonoBehaviour
{

    [Header("Audio")]
    
    [SerializeField] private AudioSource doorCloseSound = null;
    [SerializeField] private float closeDelay = 0;
    public GameObject insturctions;
   
    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Door")) 
        {
            insturctions.SetActive(true);
            Animator anim = other.GetComponentInChildren<Animator>();
            if (Input.GetKeyDown(KeyCode.E))
            {
                anim.SetTrigger("OpenClose");
                doorCloseSound.PlayDelayed(closeDelay);
                    
                
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            insturctions.SetActive(false);
        }
    }
}
