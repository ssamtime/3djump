using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class OffMeshLinkJump : MonoBehaviour
{
    [SerializeField]
    private float jumpSpeed = 10.0f; //점프속도
    [SerializeField]
    private float gravity = -9.91f; //중력 계수
    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    IEnumerator Start()
    {
        while(true)
        {
            //IsOnJump() 함수의 반환값이 true일 때 까지 반복 호출
            yield return new WaitUntil(() => IsOnJump());

            //점프 행동
            yield return StartCoroutine(JumpTo());
        }
    }

    public bool IsOnJump()
    {
        if(navMeshAgent.isOnOffMeshLink)
        {
            // mesh에 닿았다면 현재 위치의 OffMeshLink의 데이터
            OffMeshLinkData linkData = navMeshAgent.currentOffMeshLinkData;

            //OffMeshLinkType은 Manual(수동) =0, DropDown(수직낙하) =1, JumpACross(수평점프) =2 
            //자동으로 생성한 OffMeshLink의 속성 구분을 위해 사용

            // 햔재 위치에 있는 OffMeshLink의 OffMeshLinkType 이 JumpAcross면
            if(linkData.linkType == OffMeshLinkType.LinkTypeJumpAcross||
                linkData.linkType == OffMeshLinkType.LinkTypeDropDown)
            {
                return true;
            }
        }
        return false;
    }

    IEnumerator JumpTo()
    {
        // 네비게이션을 이용한 이동을 잠시 중지
        navMeshAgent.isStopped = true;

        //현재 위치에 있는 OffMeshLink의 시작/종료 위치
        OffMeshLinkData linkData = navMeshAgent.currentOffMeshLinkData;
        Vector3 start = transform.position;
        Vector3 end = linkData.endPos;

        //뛰어서 이동하는 시간 설정
        float jumpTime = Mathf.Max(0.3f, Vector3.Distance(start, end) / jumpSpeed);
        float currentTime = 0.0f;
        float percent = 0.0f;
        // y 방향의 초기속도
        float v0 = (end - start).y - gravity; 
        
        while(percent <1)
        {
            //단순히 deltaTime 만 더하면 무조건 1초 후에 percent가 1이되기 때문에
            //jumpTime 변수를 연산해서 시간을 조절한다.
            currentTime += Time.deltaTime;
            percent = currentTime / jumpTime;

            //시간 경과(최대 1)에 따라 오브젝트 위치(x,z)를 바꿔준다.
            Vector3 position = Vector3.Lerp(start, end, percent); //percent는 시간, lerp:선형보간

            //시간 경과에 따라 오브젝트의 위치y 를 바꿔준다
            //포물선운동 : 시작위치 + 초기속도*시간 +중력*시간제곱
            position.y = start.y + (v0 * percent) + (gravity * (percent * percent));

            //위에서 계산한 x,y,z 위치값을 실제 오브젝트에 대입
            transform.position = position;

            yield return null;
        }

        // OffMeshLink를 이용한 이동 완료
        navMeshAgent.CompleteOffMeshLink();
        //OffMeshLink 이동이 완료되었으니 네비게이션을 이용한 이동을 다시시작한다.
        navMeshAgent.isStopped = false;
    }


}
