using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform playerTransform; // 플레이어의 위치값 가져오기

    // 방 클릭 시 그 방의 point로 이동하는 메소드
    public void MovePlayerToRoom(GameObject room)
    {
        // RoomInfo 정보를 받아옴
        RoomInfo roomInfo = room.GetComponent<RoomInfo>();
        if (roomInfo != null && roomInfo.point1 != null)
        {
            // RoomInfo에서 제공하는 point1 위치로 플레이어를 이동시킵니다.
            playerTransform.position = roomInfo.point1.position;
            Debug.Log("플레이어 이동: 방 번호 " + roomInfo.RoomNumber + "의 point1 위치로 이동");
        }
        else
        {
            Debug.LogError("RoomInfo 컴포넌트 또는 point1이 없습니다.");
        }
    }
}
