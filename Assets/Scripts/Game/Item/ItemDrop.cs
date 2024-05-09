using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public ClickInputSystem clickInputSystem;  // Ŭ�� �Է� �ý��� ����
    public ItemProbability itemProbability;   // ������ Ȯ�� ���� ��ũ��Ʈ ����
    public ItemAni itemAni;                   // ������ �ִϸ��̼� ��ũ��Ʈ ����
    public PlayerMovement playerMovement;     // �÷��̾� �̵� ��ũ��Ʈ ����

    private void OnEnable()
    {
        clickInputSystem.OnItemClicked += HandleItemClicked;  // �̺�Ʈ ����
    }

    private void OnDisable()
    {
        clickInputSystem.OnItemClicked -= HandleItemClicked;  // �̺�Ʈ ���� ����
    }

    private void HandleItemClicked(GameObject item)
    {
        RoomInfo itemRoomInfo = item.GetComponentInParent<RoomInfo>();  // �������� ���� ���� ����
        RoomInfo playerRoomInfo = playerMovement.GetCurrentRoomInfo();
        if (itemRoomInfo == playerRoomInfo)
        {
            item.SetActive(false);                   // Ŭ���� �������� ��Ȱ��ȭ
            GameObject newItem = itemProbability.SpawnItem(item.transform.position);  // �� ������ ����
            itemAni.MoveItem(newItem);               // �� �������� �̵���Ű�� �޼��� ȣ��
        }
    }
}
