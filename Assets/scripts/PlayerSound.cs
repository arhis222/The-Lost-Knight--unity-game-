using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    // This script is used to manage the sound effects of the player character.
    [Header("Footteps")]
    // The footstep sound lists are divided into three categories based on the material the player is walking on: grass, rock, and wood.
    public List<AudioClip> grassFS;
    public List<AudioClip> rockFS;

    public List<AudioClip> woodFS;

    public List<AudioClip> dirtFS;

    enum FSMaterial
    {
        Grass, Rock, Wood, Dirt, Empty
    }
    
    private AudioSource footstepSource;
    // Start is called before the first frame update
    void Start()
    {
        footstepSource = GetComponent<AudioSource>();
    }

    

    private FSMaterial GetMaterial()

    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position + Vector3.up * 0.5f, -Vector3.up);
        Material surfaceMaterial;
        if (Physics.Raycast(ray, out hit, 1.0f, Physics.AllLayers, QueryTriggerInteraction.Ignore))
        {
            Renderer surfaceRenderer = hit.collider.GetComponentInChildren<Renderer>();
            if (surfaceRenderer)
            {
                surfaceMaterial = surfaceRenderer ? surfaceRenderer.sharedMaterial : null;
                if (surfaceMaterial.name.Contains("Grass"))
                {
                    return FSMaterial.Grass;
                }
                else if (surfaceMaterial.name.Contains("Rock"))
                {
                    return FSMaterial.Rock;
                }
                else if (surfaceMaterial.name.Contains("Wood"))
                {
                    return FSMaterial.Wood;
                }
                else if (surfaceMaterial.name.Contains("Dirt"))
                {
                    return FSMaterial.Dirt;
                }
                else
                {
                    return FSMaterial.Empty;
                }
            }

    }
    return FSMaterial.Grass;
    }

    void PlayFootStep()
    {
        FSMaterial material = GetMaterial();
        AudioClip clip = null;

        switch (material)
        {
            case FSMaterial.Grass:
                clip = grassFS[Random.Range(0, grassFS.Count)];
                break;
            case FSMaterial.Rock:
                clip = rockFS[Random.Range(0, rockFS.Count)];
                break;
            case FSMaterial.Wood:
                clip = woodFS[Random.Range(0, woodFS.Count)];
                break;
            case FSMaterial.Dirt:
                clip = dirtFS[Random.Range(0, dirtFS.Count)];
                break;
            default:
                break;
        }
        Debug.Log(material);

        if(material != FSMaterial.Empty)
        {
            footstepSource.clip = clip;
            // Randomize volume and pitch of footstep sounds
            footstepSource.volume = Random.Range(0.2f, 0.6f);
            footstepSource.pitch = Random.Range(0.8f, 1.2f);
            // Play the footstep sound
            Debug.Log(clip);
            Debug.Log(footstepSource);
            footstepSource.Play();
        }
    }
}
