using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RoomClicked : MonoBehaviour
{
    public ClickInputSystem clickInputSystem;  // 클릭 입력 시스템 참조
    public PlayerMovement playerMovement;
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
        playerMovement.MovePlayerToRoom(room); // PlayerMovement 스크립트의 메서드 호출(방 클릭하면 해당 방으로 이동)
        Transform hideTransform = room.transform.Find("Hide");  // 'Hide' 오브젝트 찾기
        if (hideTransform != null)
        {
            SpriteRenderer spriteRenderer = hideTransform.GetComponent<SpriteRenderer>();  // SpriteRenderer 컴포넌트 가져오기
            if (spriteRenderer != null)
            {
                Color newColor = spriteRenderer.color;
                newColor.a = 0;  // 투명도를 0으로 조정
                spriteRenderer.color = newColor;  // 색상 변경 적용
            }
        }
    }
}
