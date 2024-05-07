using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class StairGenerator : MonoBehaviour
{
    public GameObject stair1Prefab;  // Stair1 ������
    public GameObject stair2Prefab;  // Stair2 ������
    public Vector3 stair1StartPos;   // Stair1 ���� ��ġ
    public Vector3 stair2StartPos;   // Stair2 ���� ��ġ
    public float stairHeight = 2.9f;   // ��� ���� ���� ����
    public int stairsCount = 19;//stair2�� 10��, stair�� 9��

    void Start()
    {
        GenerateStairs();
    }

    void GenerateStairs()
    {
        int startFloor = 1;
        int endFloor = 2;

        for (int i = 0; i < stairsCount; i++)
        {
            GameObject stairPrefab;
            Vector3 position;

            // �����ư��鼭 ��� ���� �� ��ġ ����
            if (i % 2 == 0) // ¦�� �ε���: stair2 (0, 2, 4, ...)
            {
                stairPrefab = stair2Prefab;
                position = new Vector3(stair2StartPos.x, stair2StartPos.y + i * stairHeight, stair2StartPos.z);
            }
            else // Ȧ�� �ε���: stair1 (1, 3, 5, ...)
            {
                stairPrefab = stair1Prefab;
                // ù ��° stair1 ���� ��ġ ����: i == 1�� ���� stairHeight�� �߰����� ����
                position = new Vector3(stair1StartPos.x, stair1StartPos.y + (i == 1 ? 0 : (i - 1) * stairHeight), stair1StartPos.z);
            }

            // ��� �ν��Ͻ� ����
            GameObject stairInstance = Instantiate(stairPrefab, position, Quaternion.identity, this.transform);
            StairInfo stairInfo = stairInstance.GetComponent<StairInfo>(); // ���� ������Ʈ ���� ��������
            if (stairInfo != null)
            {
                stairInfo.StartFloor = startFloor;
                stairInfo.EndFloor = endFloor;
            }
            startFloor++;
            endFloor++;
        }
    }
}
