using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{//�� Ŭ�� �� ��Ʋ ��ũ���� ������ �ϴ� ��ũ��Ʈ
    public ClickInputSystem clickInputSystem;  // Ŭ�� �Է� �ý��� ����
    public GameObject battleWindow;            // ���� â ������Ʈ
    public EnemyStateUI enemyStateUI;          // �� ���� UI ��ũ��Ʈ ����
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
            // UI ������Ʈ�� BattleManager�� �� ����
            enemyStateUI.UpdateEnemyState(enemyHealth.enemyState, enemyHealth.currentHealth);
            BattleManager.Instance.SetCurrentEnemy(enemyHealth.enemyState, enemyHealth);
            battleWindow.SetActive(true);  // ���� â Ȱ��ȭ
            enemy_State_Obj.SetActive(true);//���߿� �濡 ���� ������ Ȱ��ȭ �ǰԲ� ���� �ʿ�

            Debug.Log("���� ����! ��: " + enemy.name);
        }
    }
}
