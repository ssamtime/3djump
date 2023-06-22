using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController1D : MonoBehaviour
{
    private Animator animator;
    //private float walkSpeed = 4.0f;
    //private float runSpeed = 8.0f;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float vertical = Input.GetAxis("Vertical"); //위,아래 방향키 입력
        //shift 키 안누르면 최대 0.5, 누르면 1까지
        float offset = 0.5f + Input.GetAxis("Sprint") + 0.5f;
        //
        //
        float moveParameter = Mathf.Abs(vertical * offset);
        //
        animator.SetFloat("moveSpeed", moveParameter);
        //
        //


    }

}
