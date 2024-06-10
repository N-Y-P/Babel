using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnemyStateUI : MonoBehaviour
{
    public Player player;
    //Ŭ���� ���� ü�� ����ui�� ǥ��
    //1, 2, 3�� �׸� ������ text ���� �ο�
    [Header("�� ����")]
    public GameObject enemy_State;//���� �ִ� �濡�� true
    public TMP_Text hp_Text;

    [Header("��Ʋ ��ũ������ ���� �����ϴ� ����")]
    public TMP_Text[] accuracyTexts;
    public TMP_Text[] damageMultiplierTexts;
    public TMP_Text[] guiltValueTexts;

    public void UpdateEnemyState(EnemyState enemyState, float currentHealth)
    {
        // ���� ���� ü���� ǥ��
        hp_Text.text = currentHealth + "/" + enemyState.enemy_Maxhp; // ���� ���� ü�� ǥ��

        // �� ���� �ɼǿ� ���� ������ UI�� ������Ʈ
        for (int i = 0; i < enemyState.attackOptions.Length; i++)
        {
            if (i < accuracyTexts.Length && i < damageMultiplierTexts.Length && i < guiltValueTexts.Length)
            {
                accuracyTexts[i].text = "���߷� : " + enemyState.attackOptions[i].accuracy + "%";
                damageMultiplierTexts[i].text = "������ : " + 
                    (player.MinAttackCapability * enemyState.attackOptions[i].damageMultiplier) + " - " + 
                    (player.MaxAttackCapability * enemyState.attackOptions[i].damageMultiplier);
                guiltValueTexts[i].text = "��å�� : " + enemyState.attackOptions[i].guiltValue;
            }
        }
    }
}
