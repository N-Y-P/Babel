using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public ClickInputSystem clickInputSystem;  // Ŭ�� �Է� �ý��� ����
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
        Vector3 spawnPosition = item.transform.position;//�������� ������ ��ġ�� Ŭ���� ǥ���� ��ġ
        itemProbability.SpawnItem(spawnPosition);  // �� ������ ����
    }
}
