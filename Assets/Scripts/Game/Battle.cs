using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    public ClickInputSystem clickInputSystem;  // Ŭ�� �Է� �ý��� ����
    public GameObject battleWindow;            // ���� â ������Ʈ

    private void OnEnable()
    {
        clickInputSystem.OnEnemyClicked += HandleEnemyClicked;
    }

    private void OnDisable()
    {
        clickInputSystem.OnEnemyClicked -= HandleEnemyClicked;
    }

    private void HandleEnemyClicked(GameObject enemy)
    {
        battleWindow.SetActive(true);  // ���� â Ȱ��ȭ
        Debug.Log("���� ����! ��: " + enemy.name);
    }
}
