using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorInfo : MonoBehaviour
{
    

    Animator animator;
    AnimatorClipInfo[] animatorinfo;
    string current_animation;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animatorinfo = this.animator.GetCurrentAnimatorClipInfo(0);
        current_animation = animatorinfo[0].clip.name;
    }

    void OnGUI()
    {
        GUI.skin.label.fontSize = 30; 
        GUI.Label(new Rect(1500, 25, 400, 200),  "Current State : " + current_animation);
        //  GUI.Label(new Rect(25, 25, 200, 20),  "Speed of State : " + m_CurrentSpeed);
    }
}

