using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public Transform playerTransform; // �÷��̾��� ��ġ�� ��������
    public PlayerAni playerAni; //�̵� �� �ִϸ��̼�
    private RoomInfo currentRoomInfo; // ���� �÷��̾ ��ġ�� �� ���� ����

    // �� Ŭ�� �� �� ���� point�� �̵��ϴ� �޼ҵ�
    public void MovePlayerToRoom(GameObject room)
    {
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

        Vector3 targetPosition;

        // ���� ��ġ ������ ������ �� �� ����
        if (currentRoomInfo != null)
        {
            if (currentRoomInfo.RoomNumber < newRoomInfo.RoomNumber)
            {
                // ���ο� �� ��ȣ�� �� ũ�� point1���� �̵�
                targetPosition = newRoomInfo.point1.position;
            }
            else
            {
                // ���ο� �� ��ȣ�� �� �۰ų� ������ point2�� �̵� (���ǿ� ���� ���� ����)
                targetPosition = newRoomInfo.point2.position;
            }
        }
        else
        {
            // ���� �� ������ ���� ��� (ó�� �̵��ϴ� ���) �⺻������ point1�� �̵�
            targetPosition = newRoomInfo.point1.position;
        }

        // �̵� �ִϸ��̼� ����
        playerAni.MoveToPosition(targetPosition);
        Debug.Log("Player moves to: Room " + newRoomInfo.RoomNumber + " at position point1 or point2");

        // ���� �� ���� ������Ʈ
        currentRoomInfo = newRoomInfo;
    }
    /*
    public RoomInfo CurrentRoomInfo
    {
        get { return currentRoomInfo; }
    }
    */
}

