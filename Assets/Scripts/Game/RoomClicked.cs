using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RoomClicked : MonoBehaviour
{
    public ClickInputSystem clickInputSystem;  // Ŭ�� �Է� �ý��� ����
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
        playerMovement.MovePlayerToRoom(room); // PlayerMovement ��ũ��Ʈ�� �޼��� ȣ��(�� Ŭ���ϸ� �ش� ������ �̵�)
        Transform hideTransform = room.transform.Find("Hide");  // 'Hide' ������Ʈ ã��
        if (hideTransform != null)
        {
            SpriteRenderer spriteRenderer = hideTransform.GetComponent<SpriteRenderer>();  // SpriteRenderer ������Ʈ ��������
            if (spriteRenderer != null)
            {
                Color newColor = spriteRenderer.color;
                newColor.a = 0;  // ������ 0���� ����
                spriteRenderer.color = newColor;  // ���� ���� ����
            }
        }
    }
}
