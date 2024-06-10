using JetBrains.Annotations;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    /***ü��***/
    [Header("ü��")]
    [SerializeField] private int max_Hp = 100;//ü�� �ִ�ġ
    [SerializeField] private float current_hp = 100;//���� ü��
    [Space(10)]

    /***���ŷ�***/
    [Header("���ŷ�")]
    [SerializeField] private int max_Mental = 100;//���ŷ� �ִ�ġ
    [SerializeField] private float current_mental = 0;//���� ���ŷ�
    [Space(10)]

    /***����ġ***/
    [Header("����ġ")]
    [SerializeField] private float exp = 100;//ī�� �̺�Ʈ���� �ʿ��� ����ġ
    [SerializeField] private int current_exp = 0;//���� ����ġ

    /***���߷�***/
    //ī����� �� ���. �⺻�� 0
    [Header("���߷�")]
    [SerializeField] private int accuracy_Rate = 0;

    /***�⺻���ݷ�***/
    //ī�� ���� �� ���. �⺻�� 0
    [Header("���� ���ݷ�")]
    [SerializeField] private int basic_Capability = 0;

    /***���� ���ݷ�***/
    //���� �÷��̾� ���ݷ�(���� ���ݷ� + ���� ���ݷ�)
    [Header("���� ���ݷ�")]
    private Equipment equippedWeapon; // �÷��̾ ���� ������ ����
    //���� �ּҰ��ݷ��� ���� ���ݷ� + (���� ������ ���Ⱑ �ִٸ� ���������� �ּ� ������)
    public int MinAttackCapability => basic_Capability + (equippedWeapon != null ? equippedWeapon.minDamage : 2);
    public int MaxAttackCapability => basic_Capability + (equippedWeapon != null ? equippedWeapon.maxDamage : 3);


    // ���� ���� �޼���
    public void EquipWeapon(Equipment weapon)
    {
        equippedWeapon = weapon;
    }
    // ������Ƽ
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
