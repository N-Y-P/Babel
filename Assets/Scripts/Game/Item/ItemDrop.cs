using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public ClickInputSystem clickInputSystem;  // 클릭 입력 시스템 참조
    public ItemProbability itemProbability;   // 아이템 확률 관리 스크립트 참조
    public ItemAni itemAni;                   // 아이템 애니메이션 스크립트 참조
    public PlayerMovement playerMovement;     // 플레이어 이동 스크립트 참조

    private void OnEnable()
    {
        clickInputSystem.OnItemClicked += HandleItemClicked;  // 이벤트 구독
    }

    private void OnDisable()
    {
        clickInputSystem.OnItemClicked -= HandleItemClicked;  // 이벤트 구독 해제
    }

    private void HandleItemClicked(GameObject item)
    {
        RoomInfo itemRoomInfo = item.GetComponentInParent<RoomInfo>();  // 아이템이 속한 방의 정보
        RoomInfo playerRoomInfo = playerMovement.GetCurrentRoomInfo();
        if (itemRoomInfo == playerRoomInfo)
        {
            item.SetActive(false);                   // 클릭된 아이템을 비활성화
            GameObject newItem = itemProbability.SpawnItem(item.transform.position);  // 새 아이템 생성
            itemAni.MoveItem(newItem);               // 새 아이템을 이동시키는 메서드 호출
        }
    }
}
