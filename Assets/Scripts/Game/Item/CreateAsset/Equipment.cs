using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/New Equipment")]
public class Equipment : Item
{
    public int minDamage; // ������ �ּ� ������
    public int maxDamage; // ������ �ִ� ������
    public string weaponSkin; // ���⺰ ��Ų

    // ���� ������ ��ȯ �޼���
    public int GetRandomDamage()
    {
        return Random.Range(minDamage, maxDamage + 1); 
        // maxDamage + 1�� Random.Range�� �ִ밪�� exclusive�ϰ� ó���ϱ� ����
    }
}
