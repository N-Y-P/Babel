using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.EditorTools;
using UnityEngine;

public class RoomNavigator : MonoBehaviour
{
    public Transform player; // �÷��̾��� Transform
    private int currentRoomIndex = 0; // ���� �� �ε���

    // ��ư Ŭ���� �����Ͽ� ȣ��� �޼���
    public void MoveToNextRoom()
    {
        if (RoomManager.Instance.allRooms.Count == 0)
            return;

        // ���� �� �ε����� ������Ű��, ��� ���� ��ȸ�ߴٸ� ó������ ����
        currentRoomIndex = (currentRoomIndex + 1) % RoomManager.Instance.allRooms.Count;

        // �÷��̾��� ��ġ�� ���õ� ���� point1 ��ġ�� ������Ʈ
        player.position = RoomManager.Instance.allRooms[currentRoomIndex].point1.position;
    }

    public void ResetNavigator()
    {
        currentRoomIndex = 0; // �ε��� ����
    }
}
