using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public Transform playerTransform; // 플레이어의 위치값 가져오기
    public PlayerAni playerAni; //이동 시 애니메이션
    private RoomInfo currentRoomInfo; // 현재 플레이어가 위치한 방 정보 저장
    public CameraMove cameraMove;
    float targetYRotation = 0;

    // 방 클릭 시 그 방의 point로 이동하는 메소드
    public void MovePlayerToRoom(GameObject room)
    {
        // RoomInfo 정보를 받아옴
        RoomInfo newRoomInfo = room.GetComponent<RoomInfo>();
        if (newRoomInfo == null)
        {
            Debug.LogError("RoomInfo 컴포넌트를 찾을 수 없습니다.");
            return;
        }

        // 새로운 방과 현재 방이 같다면 이동하지 않음
        if (currentRoomInfo != null && currentRoomInfo.RoomNumber == newRoomInfo.RoomNumber)
        {
            Debug.Log("이미 도착한 방입니다: Room " + newRoomInfo.RoomNumber);
            return;
        }

        Vector3 targetPosition;

        // 현재 위치 정보가 있으면 비교 후 결정
        if (currentRoomInfo != null)
        {
            if (currentRoomInfo.RoomNumber < newRoomInfo.RoomNumber)
            {
                // 새로운 방 번호가 더 크면 point1으로 이동
                cameraMove.VirtualCamera1();
                targetYRotation = 180;
                targetPosition = newRoomInfo.point1.position;
                
            }
            else
            {
                // 새로운 방 번호가 더 작거나 같으면 point2로 이동 (조건에 따라 변경 가능)
                cameraMove.VirtualCamera2();
                targetYRotation = 0;
                targetPosition = newRoomInfo.point2.position;
            }
        }
        else
        {
            // 현재 방 정보가 없는 경우 (처음 이동하는 경우) 기본적으로 point1로 이동
            cameraMove.VirtualCamera1();
            targetYRotation = 180;
            targetPosition = newRoomInfo.point1.position;
        }

        // 이동 애니메이션 실행
        playerAni.MoveToPosition(targetPosition);
        Debug.Log("플레이어 방 이동 : Room " + newRoomInfo.RoomNumber);
        playerTransform.eulerAngles = new Vector3(
            playerTransform.eulerAngles.x, 
            targetYRotation, 
            playerTransform.eulerAngles.z);

        // 현재 방 정보 업데이트
        currentRoomInfo = newRoomInfo;
    }
}

