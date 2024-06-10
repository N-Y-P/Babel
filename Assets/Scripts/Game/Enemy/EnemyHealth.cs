using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public EnemyState enemyState; // 적의 공통 속성을 가진 ScriptableObject 참조
    public float currentHealth;   // 적의 현재 체력
    public bool alive = true;

    void Start()
    {
        currentHealth = enemyState.enemy_Maxhp; // 최대 체력으로 초기화
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0) { 
            alive = false;
        }
    }
}
