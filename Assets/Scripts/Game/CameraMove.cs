using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraMove : MonoBehaviour
{
    public CinemachineVirtualCamera P1Camera; // P1Camera 객체
    public Transform playerTransform; // 플레이어 Transform 객체

    void Start()
    {
        // 초기에 카메라의 Follow 속성을 플레이어로 설정
        P1Camera.Follow = playerTransform;
    }

    void Update()
    {
        // 카메라가 계속 플레이어를 따라가도록 매 프레임마다 Follow 속성을 업데이트
        P1Camera.Follow = playerTransform;
    }
}
