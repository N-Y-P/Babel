using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Medicine", menuName = "Inventory/New Medicine")]
public class Medicine : Item
{
    public int healthEffect; // 체력 영향 (업/다운)
    public int mentalEffect; // 정신력 영향 (업/다운)
}
