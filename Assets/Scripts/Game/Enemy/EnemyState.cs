using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy/New Enemy")]
public class EnemyState : ScriptableObject
{
    public string enemy_Name;
    public AttackOption[] attackOptions; // ���� �ɼ� �迭
    [System.Serializable]
    public struct AttackOption
    {
        public float accuracy; // ���߷�
        public float damageMultiplier; // ������ ����
        public int guiltValue; // �ο��ϴ� ��å��
    }

    public int enemy_Maxhp; //�ڲ� �ڽ��� Ŭ�а� ü���� �����ؼ� �Ϲ� ��ũ��Ʈ�� ������
    //public float enemy_Hp;//�� ü��
    public int enemy_Exp;//�� óġ�� ����ġ

    public int minDamage; // ���� �ּ� ������
    public int maxDamage; //���� �ִ� ������

    //���� �÷��̾�� �ִ� ������
    public int GetRandomDamage()
    {
        return Random.Range(minDamage, maxDamage + 1);
    }
}
