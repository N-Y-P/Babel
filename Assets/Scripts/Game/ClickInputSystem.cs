using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickInputSystem : MonoBehaviour
{
    public event Action<GameObject> OnEnemyClicked;  // Enemy Ŭ�� �̺�Ʈ
    public event Action<GameObject> OnItemClicked;   // Item Ŭ�� �̺�Ʈ
    public event Action<GameObject> OnRoomClicked; //Room Ŭ�� �̺�Ʈ
    public event Action<GameObject> OnRecipeClicked; // Recipe Ŭ�� �̺�Ʈ
    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (rayHit.collider != null)
        {
            switch (rayHit.collider.tag)
            {
                case "Enemy":
                    OnEnemyClicked?.Invoke(rayHit.collider.gameObject);
                    break;
                case "Item":
                    OnItemClicked?.Invoke(rayHit.collider.gameObject);
                    break;
                case "Room":
                    OnRoomClicked?.Invoke(rayHit.collider.gameObject);
                    break;
                case "Recipe":
                    OnRecipeClicked?.Invoke(rayHit.collider.gameObject); // ������ Ŭ�� ó��
                    break;
            }
        }
    }
}
