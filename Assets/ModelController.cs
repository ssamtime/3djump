using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelController : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            animator.SetFloat("moveSpeed",0);
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            animator.SetFloat("moveSpeed", 5.0f);
        }
    }
}
