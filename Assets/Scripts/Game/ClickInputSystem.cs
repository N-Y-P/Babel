using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickInputSystem : MonoBehaviour
{
    public event Action<GameObject> OnEnemyClicked;  // Enemy 클릭 이벤트
    public event Action<GameObject> OnItemClicked;   // Item 클릭 이벤트
    public event Action<GameObject> OnRoomClicked; //Room 클릭 이벤트
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
            if (rayHit.collider.CompareTag("Enemy"))
            {
                OnEnemyClicked?.Invoke(rayHit.collider.gameObject);
            }
            else if (rayHit.collider.CompareTag("Item"))
            {
                OnItemClicked?.Invoke(rayHit.collider.gameObject);
            }
            else if(rayHit.collider.CompareTag("Room"))
            {
                OnRoomClicked?.Invoke(rayHit.collider.gameObject);
            }
        }
    }
}
