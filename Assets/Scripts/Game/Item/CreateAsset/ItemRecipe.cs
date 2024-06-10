using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "New Recipe/Recipe")]
public class ItemRecipe : ScriptableObject
{
    public Item resultItem; // 이 레시피로 만들어지는 아이템
    public Ingredient[] ingredients; // 필요한 재료 목록

    [System.Serializable]
    public struct Ingredient
    {
        public Item item; // 재료 아이템
        public int quantity; // 필요한 수량
    }
}
