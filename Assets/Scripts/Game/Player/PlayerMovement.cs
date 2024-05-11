using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public Transform playerTransform; // �÷��̾��� ��ġ�� ��������
    public PlayerAni playerAni; //�̵� �� �ִϸ��̼�
    public ClimbingStairs climbingStairs; // ��� �̵� ����
    private RoomInfo currentRoomInfo; // ���� �÷��̾ ��ġ�� �� ���� ����
    public CameraMove cameraMove;
    float targetYRotation = 0;

    // ���� �÷��̾��� �� ������ ��ȯ�ϴ� �޼���
    public RoomInfo GetCurrentRoomInfo()
    {
        return currentRoomInfo;
    }

    // �� Ŭ�� �� �� ���� point�� �̵��ϴ� �޼ҵ�
    public void MovePlayerToRoom(GameObject room)
    {

        #region
        /*
        // RoomInfo ������ �޾ƿ�
        RoomInfo newRoomInfo = room.GetComponent<RoomInfo>();
        if (newRoomInfo == null)
        {
            Debug.LogError("RoomInfo ������Ʈ�� ã�� �� �����ϴ�.");
            return;
        }

        // ���ο� ��� ���� ���� ���ٸ� �̵����� ����
        if (currentRoomInfo != null && currentRoomInfo.RoomNumber == newRoomInfo.RoomNumber)
        {
            Debug.Log("�̹� ������ ���Դϴ�: Room " + newRoomInfo.RoomNumber);
            return;
        }

        // �⺻ �̵� ��ġ�� ���� �÷��̾� ��ġ�� �ʱ�ȭ
        Vector3 targetPosition = playerTransform.position;
        
        // ���� ��ġ ������ ������ �� �� ����
        if (currentRoomInfo != null)
        {
            if(currentRoomInfo.CurrenFloor < newRoomInfo.CurrenFloor)
            {//���� ���� �� ���� ��ȣ���� �۴ٸ� (���� : 1->2��)(�ö󰥶�)
             // ��� ������ ���� ȣ��
                StairInfo stair = climbingStairs.FindStair(currentRoomInfo.CurrenFloor, newRoomInfo.CurrenFloor);
                if (stair != null)
                {
                    StartCoroutine(climbingStairs.ClimbUpStairs(stair));
                }
                if (newRoomInfo.CurrenFloor % 2 == 0)//���� �� ���� ��ȣ�� ¦�����
                {
                    cameraMove.VirtualCamera2();
                    targetYRotation = 0;
                    targetPosition = newRoomInfo.point2.position;

                }
                else//�� ���� ��ȣ�� Ȧ��(���� : 2->3��)
                {
                    cameraMove.VirtualCamera1();
                    targetYRotation = 180;
                    targetPosition = newRoomInfo.point1.position;
                }


            }
            else if(currentRoomInfo.CurrenFloor > newRoomInfo.CurrenFloor)
            {//��������
             // ��� ������ ���� ȣ��
                StairInfo stair = climbingStairs.FindStair(currentRoomInfo.CurrenFloor, newRoomInfo.CurrenFloor);
                if (stair != null)
                {
                    StartCoroutine(climbingStairs.ClimbDownStairs(stair));
                }
                if (newRoomInfo.CurrenFloor % 2 == 0)//���� ¦�����̶��(3->2��)
                {
                    // point1���� �̵�
                    cameraMove.VirtualCamera1();
                    targetYRotation = 180;
                    targetPosition = newRoomInfo.point1.position;
                }
                else//(2->1��)
                {
                    cameraMove.VirtualCamera2();
                    targetYRotation = 0;
                    targetPosition = newRoomInfo.point2.position;
                }

            }
            else if(currentRoomInfo.CurrenFloor == newRoomInfo.CurrenFloor)
            {// ���� �� ������ �̵� 
                if(currentRoomInfo.CurrenFloor % 2 == 0)
                {//���� ���� ¦�� //�� ��ȣ�� Ŀ���� point2��, �۾����� 1��
                    if (currentRoomInfo.RoomNumber < newRoomInfo.RoomNumber)
                    {
                        cameraMove.VirtualCamera2();
                        targetYRotation = 0;
                        targetPosition = newRoomInfo.point2.position;
                        
                    }
                    else
                    {
                        // point1���� �̵�
                        cameraMove.VirtualCamera1();
                        targetYRotation = 180;
                        targetPosition = newRoomInfo.point1.position;
                    }
                }
                else
                {//���� ���� Ȧ�� //�� ��ȣ�� Ŀ���� point1��, �۾����� 2��
                    if (currentRoomInfo.RoomNumber < newRoomInfo.RoomNumber)
                    {
                        // point1���� �̵�
                        cameraMove.VirtualCamera1();
                        targetYRotation = 180;
                        targetPosition = newRoomInfo.point1.position;
                    }
                    else
                    {
                        cameraMove.VirtualCamera2();
                        targetYRotation = 0;
                        targetPosition = newRoomInfo.point2.position;
                    }
                }
            }

        }
        else
        {
            // ���� �� ������ ���� ��� (ó�� �̵��ϴ� ���) �⺻������ point1�� �̵�
            cameraMove.VirtualCamera1();
            targetYRotation = 180;
            targetPosition = newRoomInfo.point1.position;
        }

        // �̵� �ִϸ��̼� ����
        playerAni.MoveToPosition(targetPosition);
        Debug.Log("�÷��̾� �� �̵� : Room " + newRoomInfo.RoomNumber);
        playerTransform.eulerAngles = new Vector3(
            playerTransform.eulerAngles.x, 
            targetYRotation, 
            playerTransform.eulerAngles.z);

        // ���� �� ���� ������Ʈ
        currentRoomInfo = newRoomInfo;
        */
        #endregion
        RoomInfo newRoomInfo = room.GetComponent<RoomInfo>();
        if (newRoomInfo == null)
        {
            Debug.LogError("RoomInfo ������Ʈ�� ã�� �� �����ϴ�.");
            return;
        }

        if (currentRoomInfo != null && currentRoomInfo.RoomNumber == newRoomInfo.RoomNumber)
        {
            Debug.Log("�̹� �ش� �濡 �ֽ��ϴ�: Room " + newRoomInfo.RoomNumber);
            return;
        }

        if (currentRoomInfo != null && currentRoomInfo.CurrenFloor != newRoomInfo.CurrenFloor)
        {
            StairInfo stair = climbingStairs.FindStair(currentRoomInfo.CurrenFloor, newRoomInfo.CurrenFloor);
            if (stair != null)
            {
                System.Action onComplete = () => {
                    MoveToFinalPosition(newRoomInfo);
                };

                if (currentRoomInfo.CurrenFloor < newRoomInfo.CurrenFloor)
                {
                    StartCoroutine(climbingStairs.ClimbUpStairs(stair, onComplete));
                }
                else
                {
                    StartCoroutine(climbingStairs.ClimbDownStairs(stair, onComplete));
                }
            }
            else
            {
                Debug.LogError("������ ����� ã�� �� �����ϴ�.");
            }
        }
        else
        {
            MoveToFinalPosition(newRoomInfo);
        }
    }
    // ���� �������� �÷��̾ �̵���Ű�� �޼ҵ�
    private void MoveToFinalPosition(RoomInfo roomInfo)
    {
        Vector3 targetPosition = CalculateTargetPosition(roomInfo);
        playerAni.MoveToPosition(targetPosition);
        currentRoomInfo = roomInfo;
        Debug.Log("������ �̵� �Ϸ�: " + roomInfo.RoomNumber);
        playerTransform.eulerAngles = new Vector3(playerTransform.eulerAngles.x, targetYRotation, playerTransform.eulerAngles.z);
    }

    // �� ��ġ�� ����ϴ� �޼ҵ�
    private Vector3 CalculateTargetPosition(RoomInfo roomInfo)
    {
        // ���� �� ������ ���� ��� (ó�� �̵��ϴ� ���)
        if (currentRoomInfo == null)
        {
            cameraMove.VirtualCamera1();
            targetYRotation = 180;
            return roomInfo.point1.position;
        }
        // ���� ���� Ȧ��/¦�� ���ο� ���� �ٸ��� ó��
        bool isEvenFloor = currentRoomInfo.CurrenFloor % 2 == 0;

        // ���� �� �������� �� �̵� ����
        if (currentRoomInfo.CurrenFloor == roomInfo.CurrenFloor)
        {
            if (isEvenFloor) // ¦�� ��
            {
                if (currentRoomInfo.RoomNumber < roomInfo.RoomNumber)
                {
                    cameraMove.VirtualCamera2();
                    targetYRotation = 0;
                    return roomInfo.point2.position;
                }
                else
                {
                    cameraMove.VirtualCamera1();
                    targetYRotation = 180;
                    return roomInfo.point1.position;
                }
            }
            else // Ȧ�� ��
            {
                if (currentRoomInfo.RoomNumber < roomInfo.RoomNumber)
                {
                    cameraMove.VirtualCamera1();
                    targetYRotation = 180;
                    return roomInfo.point1.position;
                }
                else
                {
                    cameraMove.VirtualCamera2();
                    targetYRotation = 0;
                    return roomInfo.point2.position;
                }
            }
        }
        else // �ٸ� ������ �̵��ϴ� ���
        {
            if (isEvenFloor)//���� ���� ¦��//Ȧ�� ������ �ö� ��//�� ��ȣ�� Ŀ��
            {
                if(currentRoomInfo.RoomNumber < roomInfo.RoomNumber)
                {
                    cameraMove.VirtualCamera1();
                    targetYRotation = 180;
                    return roomInfo.point1.position;
                }
                else//Ȧ�� ������ ������ ��//�� ��ȣ�� �۾���
                {
                    cameraMove.VirtualCamera2();
                    targetYRotation = 0;
                    return roomInfo.point2.position;
                } 
            }
            else
            {//���� ���� Ȧ��//¦�� ������ �ö� ��//�� ��ȣ�� Ŀ��
                if (currentRoomInfo.RoomNumber < roomInfo.RoomNumber)
                {
                    cameraMove.VirtualCamera2();
                    targetYRotation = 0;
                    return roomInfo.point2.position;
                }
                else
                {
                    cameraMove.VirtualCamera1();
                    targetYRotation = 180;
                    return roomInfo.point1.position;
                }
            }
        }
    }
}

