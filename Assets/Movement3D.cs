using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement3D : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f;
    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void MoveTo(Vector3 goalPosition)
    {
        // 기존에 이동 행동을 하고 있었다면 코루틴 중지
        StopCoroutine("OnMove");
        // 이동 속도 설정
        navMeshAgent.speed = moveSpeed;
        // 목표지점 설정 (목표까지의 경로 계산 후 알아서 움직인다.)
        navMeshAgent.SetDestination(goalPosition);
        // 이동 행동에 대한 코루틴 시작
        StartCoroutine("OnMove");
    }


    IEnumerator OnMove()
    {
        while(true)
        {
            // 목표 지점에 도달했는지 검사
            if(Vector3.Distance(navMeshAgent.destination, transform.position) 
                < 0.1f)
            {
                transform.position = navMeshAgent.destination;
                // 현재 설정되어 있는 이동 경로 초기화, 이동을 멈춤
                navMeshAgent.ResetPath();

                break;
            }
            yield return null;
        }
    }
}
