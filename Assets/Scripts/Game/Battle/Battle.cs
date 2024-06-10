using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{//적 클릭 시 배틀 스크린이 나오게 하는 스크립트
    public ClickInputSystem clickInputSystem;  // 클릭 입력 시스템 참조
    public GameObject battleWindow;            // 전투 창 오브젝트
    public EnemyStateUI enemyStateUI;          // 적 상태 UI 스크립트 참조
    public GameObject enemy_State_Obj;

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
        
        EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
        if (enemyHealth != null && enemyHealth.alive)
        {
            // UI 업데이트와 BattleManager에 적 설정
            enemyStateUI.UpdateEnemyState(enemyHealth.enemyState, enemyHealth.currentHealth);
            BattleManager.Instance.SetCurrentEnemy(enemyHealth.enemyState, enemyHealth);
            battleWindow.SetActive(true);  // 전투 창 활성화
            enemy_State_Obj.SetActive(true);//나중에 방에 적이 있으면 활성화 되게끔 수정 필요

            Debug.Log("전투 시작! 적: " + enemy.name);
        }
    }
}
