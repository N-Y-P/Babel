using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public ClickInputSystem clickInputSystem;  // 클릭 입력 시스템 참조
    public ItemProbability itemProbability;

    private void OnEnable()
    {
        clickInputSystem.OnItemClicked += HandleItemClicked;
    }

    private void OnDisable()
    {
        clickInputSystem.OnItemClicked -= HandleItemClicked;
    }

    private void HandleItemClicked(GameObject item)
    {
        item.SetActive(false);
        Vector3 spawnPosition = item.transform.position;//아이템이 생성될 위치는 클릭된 표시의 위치
        itemProbability.SpawnItem(spawnPosition);  // 새 아이템 생성
    }
}
