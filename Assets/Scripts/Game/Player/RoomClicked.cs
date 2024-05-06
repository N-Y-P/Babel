using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RoomClicked : MonoBehaviour
{
    public ClickInputSystem clickInputSystem;  // 클릭 입력 시스템 참조
    public PlayerMovement playerMovement;
    public PlayerAni playerAni;
    private GameObject currentRoom = null; // 현재 선택된 방
    private void OnEnable()
    {
        clickInputSystem.OnRoomClicked += HandleRoomClicked;
    }

    private void OnDisable()
    {
        clickInputSystem.OnRoomClicked -= HandleRoomClicked;
    }
    private void HandleRoomClicked(GameObject room)
    {
        if (playerAni.Moveable)
        {
            RoomInfo clickedRoomInfo = room.GetComponent<RoomInfo>();

            // 이전에 클릭된 방의 Collider를 다시 활성화
            if (currentRoom != null && currentRoom != room)
            {
                currentRoom.GetComponent<BoxCollider2D>().enabled = true;
            }

            // 첫 이동이고, 1층 1번 방을 클릭했는지 확인
            if (currentRoom == null && clickedRoomInfo != null && clickedRoomInfo.RoomNumber == 1 && clickedRoomInfo.CurrenFloor == 1)
            {//현재 방이 없고 && 클릭한 방의 정보가 있고 && 1층 1번방일때
                RealRoomClick(room, clickedRoomInfo);
            }
            else if (currentRoom != null)
            {
                RoomInfo currentRoomInfo = currentRoom.GetComponent<RoomInfo>();
                // 이후 이동은 앞뒤 방만 이동 가능
                if (clickedRoomInfo != null && currentRoomInfo != null &&
                    (clickedRoomInfo.RoomNumber == currentRoomInfo.RoomNumber + 1 || clickedRoomInfo.RoomNumber == currentRoomInfo.RoomNumber - 1))
                {
                    RealRoomClick(room, clickedRoomInfo);
                }
            }
        }
    }

    private void RealRoomClick(GameObject room, RoomInfo clickedRoomInfo)
    {
        playerMovement.MovePlayerToRoom(room); // 해당 방으로 이동
        currentRoom = room; // 현재 방 업데이트
        room.GetComponent<BoxCollider2D>().enabled = false; // 새로운 방의 Collider 비활성화

        Transform hideTransform = room.transform.Find("Hide"); // 'Hide' 오브젝트 찾기
        Transform itemsTransform = room.transform.Find("Items"); // 'Items' 오브젝트 찾기
        if (hideTransform != null) // 만약 hide가 있으면
        {
            SpriteRenderer spriteRenderer = hideTransform.GetComponent<SpriteRenderer>(); // SpriteRenderer 컴포넌트 가져오기
            if (spriteRenderer != null) // 스프라이트가 있으면
            {
                Color newColor = spriteRenderer.color;
                newColor.a = 0;  // 투명도를 0으로 조정
                spriteRenderer.color = newColor;  // 색상 변경 적용
                itemsTransform.gameObject.SetActive(true); // 아이템 활성화
            }
        }
    }
}
