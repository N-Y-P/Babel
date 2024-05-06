using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraMove : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera1;
    public CinemachineVirtualCamera virtualCamera2; 

    public void VirtualCamera1()//point1�϶� 
    {
        // Virtual Camera 1�� �켱������ ���� Ȱ��ȭ
        virtualCamera1.Priority = 10;
        virtualCamera2.Priority = 5;
        Debug.Log("Virtual Camera 1 Ȱ��ȭ");
    }

    public void VirtualCamera2()//point2�϶�
    {
        // Virtual Camera 2�� �켱������ ���� Ȱ��ȭ
        virtualCamera1.Priority = 5;
        virtualCamera2.Priority = 10;
        Debug.Log("Virtual Camera 2 Ȱ��ȭ");
    }
}
