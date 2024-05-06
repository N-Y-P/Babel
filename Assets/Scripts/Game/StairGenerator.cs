using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class StairGenerator : MonoBehaviour
{
    public GameObject stair1Prefab;  // Stair1 프리팹
    public GameObject stair2Prefab;  // Stair2 프리팹
    public Vector3 stair1StartPos;   // Stair1 시작 위치
    public Vector3 stair2StartPos;   // Stair2 시작 위치
    public float stairHeight = 2.9f;   // 계단 간의 높이 간격
    public int stairsCount = 19;//stair2가 10개, stair가 9개

    void Start()
    {
        GenerateStairs();
    }

    void GenerateStairs()
    {
        for (int i = 0; i < stairsCount; i++)
        {
            GameObject stairPrefab;
            Vector3 position;

            // 번갈아가면서 계단 선택 및 위치 결정
            if (i % 2 == 0) // 짝수 인덱스: stair2 (0, 2, 4, ...)
            {
                stairPrefab = stair2Prefab;
                position = new Vector3(stair2StartPos.x, stair2StartPos.y + i * stairHeight, stair2StartPos.z);
            }
            else // 홀수 인덱스: stair1 (1, 3, 5, ...)
            {
                stairPrefab = stair1Prefab;
                // 첫 번째 stair1 생성 위치 조정: i == 1일 때는 stairHeight를 추가하지 않음
                position = new Vector3(stair1StartPos.x, stair1StartPos.y + (i == 1 ? 0 : (i - 1) * stairHeight), stair1StartPos.z);
            }

            // 계단 인스턴스 생성
            Instantiate(stairPrefab, position, Quaternion.identity, this.transform);
        }
    }
}
