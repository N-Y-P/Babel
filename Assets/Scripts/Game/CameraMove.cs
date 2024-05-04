using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraMove : MonoBehaviour
{
    public CinemachineVirtualCamera P1Camera; // P1Camera ��ü
    public Transform playerTransform; // �÷��̾� Transform ��ü

    void Start()
    {
        // �ʱ⿡ ī�޶��� Follow �Ӽ��� �÷��̾�� ����
        P1Camera.Follow = playerTransform;
    }

    void Update()
    {
        // ī�޶� ��� �÷��̾ ���󰡵��� �� �����Ӹ��� Follow �Ӽ��� ������Ʈ
        P1Camera.Follow = playerTransform;
    }
}
