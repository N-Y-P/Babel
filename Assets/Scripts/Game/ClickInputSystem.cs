using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickInputSystem : MonoBehaviour
{
    public event Action<GameObject> OnEnemyClicked;  // Enemy Ŭ�� �̺�Ʈ
    public event Action<GameObject> OnItemClicked;   // Item Ŭ�� �̺�Ʈ
    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        /*
        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(pos: (Vector3)Mouse.current.position.ReadValue()));
        if (!rayHit.collider) return;

        Debug.Log("�ݸ��� �ִ� ������Ʈ Ŭ�� �̸� : " +rayHit.collider.gameObject.name);
        */
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
        }
    }
}
