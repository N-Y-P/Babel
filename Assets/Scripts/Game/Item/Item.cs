using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]
public class Item : ScriptableObject  // ���� ������Ʈ�� ���� �ʿ� X 
{
    public enum ItemType  // ������ ����
    {
        Equipment,//����
        Medicine,//ü�¾�, ���ž�
        Ingredient,//���
    }

    public string itemName; // �������� �̸�
    public ItemType itemType; // ������ ����
    public Sprite itemImage; // �������� �̹���(�κ��丮 �ȿ��� ���)
    public int itemID;//������ ��ȣ

    [TextArea(1, 10)]
    public string itemDescription; // ������ ����
}
