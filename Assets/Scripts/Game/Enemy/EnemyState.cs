using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy/New Enemy")]
public class EnemyState : ScriptableObject
{
    public string enemy_Name;
    public AttackOption[] attackOptions; // 공격 옵션 배열
    [System.Serializable]
    public struct AttackOption
    {
        public float accuracy; // 명중률
        public float damageMultiplier; // 데미지 배율
        public int guiltValue; // 부여하는 죄책감
    }

    public int enemy_Maxhp; //자꾸 자신의 클론과 체력을 공유해서 일반 스크립트로 빼버림
    //public float enemy_Hp;//적 체력
    public int enemy_Exp;//적 처치시 경험치

    public int minDamage; // 적의 최소 데미지
    public int maxDamage; //적의 최대 데미지

    //적이 플레이어에게 주는 데미지
    public int GetRandomDamage()
    {
        return Random.Range(minDamage, maxDamage + 1);
    }
}
