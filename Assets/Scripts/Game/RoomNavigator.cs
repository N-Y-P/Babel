using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.EditorTools;
using UnityEngine;

public class RoomNavigator : MonoBehaviour
{
    public Transform player; // 플레이어의 Transform
    private int currentRoomIndex = 0; // 현재 방 인덱스

    // 버튼 클릭에 반응하여 호출될 메서드
    public void MoveToNextRoom()
    {
        if (RoomManager.Instance.allRooms.Count == 0)
            return;

        // 현재 방 인덱스를 증가시키고, 모든 방을 순회했다면 처음으로 리셋
        currentRoomIndex = (currentRoomIndex + 1) % RoomManager.Instance.allRooms.Count;

        // 플레이어의 위치를 선택된 방의 point1 위치로 업데이트
        player.position = RoomManager.Instance.allRooms[currentRoomIndex].point1.position;
    }

    public void ResetNavigator()
    {
        currentRoomIndex = 0; // 인덱스 리셋
    }
}
