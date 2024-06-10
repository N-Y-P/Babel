using JetBrains.Annotations;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    /***체력***/
    [Header("체력")]
    [SerializeField] private int max_Hp = 100;//체력 최대치
    [SerializeField] private float current_hp = 100;//현재 체력
    [Space(10)]

    /***정신력***/
    [Header("정신력")]
    [SerializeField] private int max_Mental = 100;//정신력 최대치
    [SerializeField] private float current_mental = 0;//현재 정신력
    [Space(10)]

    /***경험치***/
    [Header("경험치")]
    [SerializeField] private float exp = 100;//카드 이벤트까지 필요한 경험치
    [SerializeField] private int current_exp = 0;//현재 경험치

    /***명중률***/
    //카드얻을 때 상승. 기본은 0
    [Header("명중률")]
    [SerializeField] private int accuracy_Rate = 0;

    /***기본공격력***/
    //카드 얻을 때 상승. 기본은 0
    [Header("기초 공격력")]
    [SerializeField] private int basic_Capability = 0;

    /***현재 공격력***/
    //현재 플레이어 공격력(기초 공격력 + 무기 공격력)
    [Header("현재 공격력")]
    private Equipment equippedWeapon; // 플레이어가 현재 장착한 무기
    //현재 최소공격력은 기초 공격력 + (현재 장착한 무기가 있다면 장착무기의 최소 데미지)
    public int MinAttackCapability => basic_Capability + (equippedWeapon != null ? equippedWeapon.minDamage : 2);
    public int MaxAttackCapability => basic_Capability + (equippedWeapon != null ? equippedWeapon.maxDamage : 3);


    // 무기 장착 메서드
    public void EquipWeapon(Equipment weapon)
    {
        equippedWeapon = weapon;
    }
    // 프로퍼티
    public int MaxHP
    {
        get => max_Hp;
        set => max_Hp = Mathf.Max(value, 0);
    }

    public float CurrentHP
    {
        get => current_hp;
        set => current_hp = Mathf.Clamp(value, 0, max_Hp);
    }

    public int MaxMental
    {
        get => max_Mental;
        set => max_Mental = Mathf.Max(value, 0);
    }

    public float CurrentMental
    {
        get => current_mental;
        set => current_mental = Mathf.Clamp(value, 0, max_Mental);
    }

    public float ExpRequired
    {
        get => exp;
        set => exp = Mathf.Max(value, 0);
    }

    public int CurrentExp
    {
        get => current_exp;
        set => current_exp = Mathf.Max(value, 0);
    }
}
