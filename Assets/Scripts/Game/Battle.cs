using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    public ClickInputSystem clickInputSystem;  // 클릭 입력 시스템 참조
    public GameObject battleWindow;            // 전투 창 오브젝트

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
        battleWindow.SetActive(true);  // 전투 창 활성화
        Debug.Log("전투 시작! 적: " + enemy.name);
    }
}
