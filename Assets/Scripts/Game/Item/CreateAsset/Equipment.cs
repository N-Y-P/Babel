using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/New Equipment")]
public class Equipment : Item
{
    public int minDamage; // 무기의 최소 데미지
    public int maxDamage; // 무기의 최대 데미지
    public string weaponSkin; // 무기별 스킨

    // 랜덤 데미지 반환 메서드
    public int GetRandomDamage()
    {
        return Random.Range(minDamage, maxDamage + 1); 
        // maxDamage + 1은 Random.Range가 최대값을 exclusive하게 처리하기 때문
    }
}
