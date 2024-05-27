using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]
public class Item : ScriptableObject  // 게임 오브젝트에 붙일 필요 X 
{
    public enum ItemType  // 아이템 유형
    {
        Equipment,//무기
        Medicine,//체력약, 정신약
        Ingredient,//재료
    }

    public string itemName; // 아이템의 이름
    public ItemType itemType; // 아이템 유형
    public Sprite itemImage; // 아이템의 이미지(인벤토리 안에서 띄울)
    public int itemID;//아이템 번호

    [TextArea(1, 10)]
    public string itemDescription; // 아이템 설명
}
