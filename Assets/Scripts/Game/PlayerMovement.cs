using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform playerTransform; // �÷��̾��� ��ġ�� ��������

    // �� Ŭ�� �� �� ���� point�� �̵��ϴ� �޼ҵ�
    public void MovePlayerToRoom(GameObject room)
    {
        // RoomInfo ������ �޾ƿ�
        RoomInfo roomInfo = room.GetComponent<RoomInfo>();
        if (roomInfo != null && roomInfo.point1 != null)
        {
            // RoomInfo���� �����ϴ� point1 ��ġ�� �÷��̾ �̵���ŵ�ϴ�.
            playerTransform.position = roomInfo.point1.position;
            Debug.Log("�÷��̾� �̵�: �� ��ȣ " + roomInfo.RoomNumber + "�� point1 ��ġ�� �̵�");
        }
        else
        {
            Debug.LogError("RoomInfo ������Ʈ �Ǵ� point1�� �����ϴ�.");
        }
    }
}
