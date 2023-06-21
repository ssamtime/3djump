using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Movement3D movement3D;

    private void Awake()
    {
        movement3D = GetComponent<Movement3D>();
    }

    private void Update()
    {
        // 마우스 왼쪽 버튼을 눌렀을 때
        if(Input.GetMouseButton(0))
        {
            RaycastHit hit;
            // 스크린 좌표를 인수로 넘겨주면 카메라에서 시작하여
            // 스크린 좌표에 해당하는 3차원 좌표로 ray(광선)을 생성시켜줌.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // ray.origin 위치에서 ray.direction 방향으로 Mathf.Infinity 길이의 광선을 발사
            // 광선에 부딪히는 오브젝트의 정보는 hit에 저장된다.
            // 광선에 부딪히는 오브젝트가 존재하면 Physics.Raycast()가 true가 되어
            // if 내부를 실행
            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                // 마우스가 클릭한 지점(hit.point)을 목표위치로 설정
                movement3D.MoveTo(hit.point);
            }
        }
    }
}
