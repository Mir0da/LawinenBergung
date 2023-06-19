using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovel : MonoBehaviour
{
    private Animator animator;
    public bool shovelEquipped;
    private Vector3 startPos;

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        startPos = transform.position;
    }

    private void Update()
    {
        if (animator.GetBool("HeadUnfolded") && animator.GetBool("HandleUnfolded") && shovelEquipped == false)
        {
            shovelEquipped = true;
            //translate shovel to a better position
            transform.Translate(10f, -10f,0f ,Space.Self);
            Debug.Log("Shovel Equipped!");
        }
        
        
    }

    public void setHeadBool()
    {
        animator.SetBool("HeadUnfolded", true);
        Debug.Log("Head Unfolded");
    }
    public void setHandleBool()
    {
        animator.SetBool("HandleUnfolded", true);
        Debug.Log("Handle Unfolded!");
    }
}
