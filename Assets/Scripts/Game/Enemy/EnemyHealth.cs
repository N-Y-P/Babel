using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public EnemyState enemyState; // ���� ���� �Ӽ��� ���� ScriptableObject ����
    public float currentHealth;   // ���� ���� ü��
    public bool alive = true;

    void Start()
    {
        currentHealth = enemyState.enemy_Maxhp; // �ִ� ü������ �ʱ�ȭ
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0) { 
            alive = false;
        }
    }
}
