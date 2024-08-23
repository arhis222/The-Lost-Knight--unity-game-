using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LakeWarnings : MonoBehaviour
{

    public GameObject insturctions;
   
    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Lake")) 
        {
            insturctions.SetActive(true);
            Debug.Log("Lake area");
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Lake"))
        {
            insturctions.SetActive(false);
        }
    }
}
