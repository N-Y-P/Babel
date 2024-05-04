using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class TowerGenerator : MonoBehaviour
{
    public GameObject[] LowerroomPrefabs; // �� ������ �迭
    public int floors = 20;          // �� ��
    public int roomsPerFloor = 5;    // �� �� �� ��
    public float roomWidth = 10f;    // �� �ʺ�
    public float roomHeight = 8f;    // �� ����
    public float roomSpacing = 1.0f;  // �� ������ �߰� ����
    public float roomup = 2.9f;  // �� ������ �߰� ����
    int roomnum = 0;
    void Start()
    {
        GenerateTower();
    }

    void GenerateTower()
    {
        for (int floor = 0; floor < floors; floor++)
        {
            for (int room = 0; room < roomsPerFloor; room++)
            {
                // floor�� ¦���� ��� ���ʿ��� ����������, Ȧ���� ��� �����ʿ��� �������� ���� ����
                int index;
                if (floor % 2 == 0)
                {
                    index = roomsPerFloor - 1 - room;
                }
                else
                {
                    index = room;
                }
                //int index = (floor % 2 == 0) ? room : roomsPerFloor - 1 - room;
                // �� ���� x ��ġ�� ����� �� ������ ���
                Vector3 position = new Vector3(index * (roomSpacing), floor * (roomup), 0);
                GameObject roomPrefab = LowerroomPrefabs[Random.Range(0, LowerroomPrefabs.Length)];
                GameObject roomInstance = Instantiate(roomPrefab, position, Quaternion.identity);

                // RoomInfo ������Ʈ ����
                RoomInfo roomInfo = roomInstance.GetComponent<RoomInfo>();
                if (roomInfo == null)
                {
                    roomInfo = roomInstance.AddComponent<RoomInfo>(); // RoomInfo ������Ʈ�� ������ �߰�
                }
                roomnum++;
                roomInfo.RoomNumber = roomnum;  // �� ��ȣ ����
                roomInfo.CurrenFloor = floor + 1;  // �� ��ȣ ����
            }
        }
    }
}
