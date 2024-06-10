using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static EnemyState;

public class BattleManager : MonoBehaviour
{
    [Header("�ʿ��� ������Ʈ �Ҵ�")]
    public GameObject enemy_State_Obj;//�� ���� ������Ʈ(�� ��� �� ��Ȱ ����)
    public GameObject battleWindow; // ���� â ������Ʈ
    public GameObject TransparentWall;//���� â

    [Header("��ũ��Ʈ ����")]
    public Player player; // �÷��̾� ����
    public EnemyState currentEnemy; // ���� ���� ���� ��
    public EnemyStateUI currentEnemyUI;
    public EnemyHealth currentEnemyHealth;
    //public BattleUIManager battleUImanager;
    public static BattleManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // �� �޼ҵ�� �ܺο��� ���� ���� ���� ���� EnemyState�� EnemyHealth�� �����ϱ� ���� ���
    public void SetCurrentEnemy(EnemyState enemyState, EnemyHealth enemyHealth)
    {
        currentEnemy = enemyState;
        currentEnemyHealth = enemyHealth;
        // �� ���� ���� ��, �ʿ��ϴٸ� UI ������Ʈ ������ �߰� ����
        if (currentEnemyUI != null && currentEnemyHealth != null)
        {
            currentEnemyUI.UpdateEnemyState(currentEnemy, currentEnemyHealth.currentHealth);
        }
    }
    #region /***��ư �޼ҵ�***/
    // �� ��ư Ŭ���� ȣ��� �޼ҵ�
    public void AttackOption1()
    {
        StartCoroutine(CombatSequence(0));
        //PerformAttack(0); 
    }

    public void AttackOption2()
    {
        StartCoroutine(CombatSequence(1));

        
    }

    public void AttackOption3()
    {
        StartCoroutine(CombatSequence(3));
        //PerformAttack(2); 
    }
    #endregion
    #region/***���ݽ���, ������, ��å�� �޼ҵ�***/
    // ���� ���� �޼ҵ�
    private void PerformAttack(int optionIndex)
    {
        if (currentEnemyHealth == null || optionIndex >= currentEnemyHealth.enemyState.attackOptions.Length)
        {
            Debug.LogError("�߸��� ���� �ɼ��̰ų� ���� �������� �ʾҽ��ϴ�.");
            return;
        }

        var attackOption = currentEnemyHealth.enemyState.attackOptions[optionIndex];

        // ���� Ȯ���� ����Ͽ� ������ ���� ���� ����
        if (Random.Range(0, 100) < attackOption.accuracy)
        {
            // ���� ���� ��
            // ���� ü�� ���� 
            float damage = CalculateDamage(attackOption.damageMultiplier);
            currentEnemyHealth.TakeDamage(damage);

            if (currentEnemyHealth.currentHealth <= 0)
            {
                enemy_State_Obj.SetActive(false);  // �� UI ��Ȱ��ȭ
            }

            // �� ü�� UI ������Ʈ
            if (currentEnemyUI != null)
            {
                currentEnemyUI.UpdateEnemyState(currentEnemyHealth.enemyState, currentEnemyHealth.currentHealth);  // ü�� ǥ�� ������Ʈ
            }

            // ��å�� ����
            ApplyGuilt(attackOption.guiltValue);
            BattleUIManager.Instance.DisplayEnemyDamage(damage);
            Debug.Log($"�� ���� �ɼ� {optionIndex + 1}�� ���. ����");
        }
        else
        {
            BattleUIManager.Instance.enemyText.text = "��ħ";
            // ���� �̽� ��
            Debug.Log($"�� ���� �ɼ� {optionIndex + 1}�� ���. �̽�");
        }
    }

    // ������ ��� �޼ҵ�
    private float CalculateDamage(float damageMultiplier)
    {
        // ���⿡�� �÷��̾��� ���ݷ��� �������� �������� ���
        float minDamage = player.MinAttackCapability * damageMultiplier;  // �Ҽ��� ����� �����Ͽ� �̴ϸ� ������ ���
        float maxDamage = player.MaxAttackCapability * damageMultiplier;  // �Ҽ��� ����� �����Ͽ� �ƽø� ������ ���
        float finalDamage = Random.Range(minDamage, maxDamage);  // �̴ϸذ� �ƽø� ������ ���� ���� ���� (�Ҽ��� ����)

        // �Ҽ��� ù° �ڸ����� �ݿø��Ͽ� ó��
        finalDamage = Mathf.Round(finalDamage * 10f) / 10f;

        Debug.Log($"���� �� ���� {finalDamage}");
        return finalDamage;  // �Ҽ��� ù° �ڸ�����
    }

    // ��å�� ���� �޼ҵ�
    private void ApplyGuilt(int guiltValue)
    {
        // ���⿡�� �÷��̾��� ���� ���¿� ��å���� ����
        player.CurrentMental += guiltValue;
    }
    #endregion

    // ���ݰ� �ݰ��� ó���ϴ� �ڷ�ƾ
    IEnumerator CombatSequence(int optionIndex)
    {
        // ��Ʋ ��ũ���� ��Ȱ��ȭ
        battleWindow.SetActive(false);
        //���� �� Ȱ��ȭ(�Ʒ� ������ ���� ���� �� �ٸ� Ŭ�� ����)
        TransparentWall.SetActive(true);

        yield return new WaitForSeconds(0.5f);  // ª�� ����

        // �÷��̾� ����
        PerformAttack(optionIndex);
        yield return new WaitForSeconds(1.0f);  // �÷��̾� ���� �� ���

        // �� �ݰ� 
        if (currentEnemyHealth.currentHealth > 0)
        {
            EnemyCounterAttack();
            yield return new WaitForSeconds(1.0f);  // �� ���� �� ���
        }
        else
        {
            //���� �׾��ٸ� ����ġ �ο� 
            player.CurrentExp += currentEnemyHealth.enemyState.enemy_Exp;
            BattleUIManager.Instance.DisplayExperienceGained(currentEnemyHealth.enemyState.enemy_Exp);
        }
        // ���� �� ��Ȱ��ȭ
        TransparentWall.SetActive(false);

    }
    private void EnemyCounterAttack()
    {
        // ���� �÷��̾�� ����
        float damage = currentEnemy.GetRandomDamage();
        player.CurrentHP -= damage;
        BattleUIManager.Instance.DisplayPlayerDamage(damage);
        Debug.Log($"���� {damage} ��ŭ ����");
    }
    //���� ���� �޼ҵ�(�� ��ư �޼ҵ忡 �ֱ�)
    //��Ʋ ��ũ�� �ݱ�(��)
    //���� �� true(��)
    //�÷��̾� ���� ���->������text->���� ���� ���->������ text
    //���� �� false

    //���� �� ü�� 0 ����(���)
    //false(��)
    //�� land ���
    //����ġ ���� text


}
