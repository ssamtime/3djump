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
        // ���콺 ���� ��ư�� ������ ��
        if(Input.GetMouseButton(0))
        {
            RaycastHit hit;
            // ��ũ�� ��ǥ�� �μ��� �Ѱ��ָ� ī�޶󿡼� �����Ͽ�
            // ��ũ�� ��ǥ�� �ش��ϴ� 3���� ��ǥ�� ray(����)�� ����������.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // ray.origin ��ġ���� ray.direction �������� Mathf.Infinity ������ ������ �߻�
            // ������ �ε����� ������Ʈ�� ������ hit�� ����ȴ�.
            // ������ �ε����� ������Ʈ�� �����ϸ� Physics.Raycast()�� true�� �Ǿ�
            // if ���θ� ����
            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                // ���콺�� Ŭ���� ����(hit.point)�� ��ǥ��ġ�� ����
                movement3D.MoveTo(hit.point);
            }
        }
    }
}
