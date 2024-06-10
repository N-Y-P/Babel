using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Medicine", menuName = "Inventory/New Medicine")]
public class Medicine : Item
{
    public int healthEffect; // ü�� ���� (��/�ٿ�)
    public int mentalEffect; // ���ŷ� ���� (��/�ٿ�)
}
