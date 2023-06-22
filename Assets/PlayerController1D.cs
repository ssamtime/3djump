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
        float vertical = Input.GetAxis("Vertical"); //��,�Ʒ� ����Ű �Է�
        //shift Ű �ȴ����� �ִ� 0.5, ������ 1����
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
