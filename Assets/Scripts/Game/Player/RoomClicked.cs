using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RoomClicked : MonoBehaviour
{
    public ClickInputSystem clickInputSystem;  // Ŭ�� �Է� �ý��� ����
    public PlayerMovement playerMovement;
    public PlayerAni playerAni;
    private GameObject currentRoom = null; // ���� ���õ� ��
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

            // ������ Ŭ���� ���� Collider�� �ٽ� Ȱ��ȭ
            if (currentRoom != null && currentRoom != room)
            {
                currentRoom.GetComponent<BoxCollider2D>().enabled = true;
            }

            // ù �̵��̰�, 1�� 1�� ���� Ŭ���ߴ��� Ȯ��
            if (currentRoom == null && clickedRoomInfo != null && clickedRoomInfo.RoomNumber == 1 && clickedRoomInfo.CurrenFloor == 1)
            {//���� ���� ���� && Ŭ���� ���� ������ �ְ� && 1�� 1�����϶�
                RealRoomClick(room, clickedRoomInfo);
            }
            else if (currentRoom != null)
            {
                RoomInfo currentRoomInfo = currentRoom.GetComponent<RoomInfo>();
                // ���� �̵��� �յ� �游 �̵� ����
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
        playerMovement.MovePlayerToRoom(room); // �ش� ������ �̵�
        currentRoom = room; // ���� �� ������Ʈ
        room.GetComponent<BoxCollider2D>().enabled = false; // ���ο� ���� Collider ��Ȱ��ȭ

        Transform hideTransform = room.transform.Find("Hide"); // 'Hide' ������Ʈ ã��
        Transform itemsTransform = room.transform.Find("Items"); // 'Items' ������Ʈ ã��
        if (hideTransform != null) // ���� hide�� ������
        {
            SpriteRenderer spriteRenderer = hideTransform.GetComponent<SpriteRenderer>(); // SpriteRenderer ������Ʈ ��������
            if (spriteRenderer != null) // ��������Ʈ�� ������
            {
                Color newColor = spriteRenderer.color;
                newColor.a = 0;  // ������ 0���� ����
                spriteRenderer.color = newColor;  // ���� ���� ����
                itemsTransform.gameObject.SetActive(true); // ������ Ȱ��ȭ
            }
        }
    }
}
