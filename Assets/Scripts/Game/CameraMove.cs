using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraMove : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera1;
    public CinemachineVirtualCamera virtualCamera2; 

    public void VirtualCamera1()//point1일때 
    {
        // Virtual Camera 1의 우선순위를 높여 활성화
        virtualCamera1.Priority = 10;
        virtualCamera2.Priority = 5;
        Debug.Log("Virtual Camera 1 활성화");
    }

    public void VirtualCamera2()//point2일때
    {
        // Virtual Camera 2의 우선순위를 높여 활성화
        virtualCamera1.Priority = 5;
        virtualCamera2.Priority = 10;
        Debug.Log("Virtual Camera 2 활성화");
    }
}
