using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "New Recipe/Recipe")]
public class ItemRecipe : ScriptableObject
{
    public Item resultItem; // �� �����Ƿ� ��������� ������
    public Ingredient[] ingredients; // �ʿ��� ��� ���

    [System.Serializable]
    public struct Ingredient
    {
        public Item item; // ��� ������
        public int quantity; // �ʿ��� ����
    }
}
