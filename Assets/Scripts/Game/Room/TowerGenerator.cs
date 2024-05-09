using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class TowerGenerator : MonoBehaviour
{
    public GameObject[] LowerroomPrefabs; // �� ������ �迭
    public GameObject angelRoomPrefab; // õ��� ������
    public List<int> angelRoomNumbers; // õ����� ������ �� ��ȣ ���
    public int floors = 66;          // �� ��
    public float roomSpacing = 1.0f;  // �� ������ �߰� ����
    public float roomup = 2.9f;  // �� ������ �߰� ����
    int roomnum = 0;
    Vector3 lastRoomPosition; // ���� ���� ������ ���� ��ġ ����

    void Start()
    {
        GenerateTower();
    }
    void GenerateTower()
    {
        for (int floor = 0; floor < floors; floor++)
        {
            int roomsPerFloor = RoomsPerFloor(floor); // ���� ���� �� ����
            bool isDirectionReversed = floor % 2 != 0; // ���� ����

            Vector3 startPosition = lastRoomPosition; // �� ���� ��ġ�� ���� ���� ������ �� ��ġ

            if (floor > 0 && !isDirectionReversed)
            {
                startPosition.x -= (roomsPerFloor - 1) * roomSpacing; // �� �� ���� ��ġ ����
            }

            for (int room = 0; room < roomsPerFloor; room++)
            {
                int index = isDirectionReversed ? room : roomsPerFloor - 1 - room;
                Vector3 position = new Vector3(startPosition.x + index * roomSpacing, floor * roomup, 0);
                roomnum++;
                GameObject roomPrefab = SelectRoomPrefab(roomnum); // õ��� �Ǵ� �Ϲ� �� ����
                GameObject roomInstance = Instantiate(roomPrefab, position, Quaternion.identity);

                RoomInfo roomInfo = roomInstance.GetComponent<RoomInfo>() ?? roomInstance.AddComponent<RoomInfo>();
                roomInfo.RoomNumber = roomnum;
                roomInfo.CurrenFloor = floor + 1;
                /*
                GameObject roomPrefab = LowerroomPrefabs[Random.Range(0, LowerroomPrefabs.Length)];
                GameObject roomInstance = Instantiate(roomPrefab, position, Quaternion.identity);

                RoomInfo roomInfo = roomInstance.GetComponent<RoomInfo>();
                if (roomInfo == null)
                {
                    roomInfo = roomInstance.AddComponent<RoomInfo>(); // RoomInfo ������Ʈ �߰�
                }
                roomnum++;
                roomInfo.RoomNumber = roomnum;
                roomInfo.CurrenFloor = floor + 1;
                */
                if (room == roomsPerFloor - 1)
                {
                    lastRoomPosition = position; // ������ �� ��ġ ������Ʈ
                }
            }
        }
        #region
        /*
        for (int floor = 0; floor < floors; floor++)
        {
            int roomsPerFloor = RoomsPerFloor(floor); // ���� ���� �� ����
            for (int room = 0; room < roomsPerFloor; room++)
            {
                
                // floor�� ¦���� ��� ���ʿ��� ����������, Ȧ���� ��� �����ʿ��� �������� ���� ����
                int index = (floor % 2 == 0) ? roomsPerFloor - 1 - room : room;
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
        */
        #endregion
    }
    // �� ��ȣ�� ���� ������ ����
    GameObject SelectRoomPrefab(int roomNumber)
    {
        if (angelRoomNumbers.Contains(roomNumber))
        {
            return angelRoomPrefab; // õ��� ������ ��ȯ
        }
        else
        {
            return LowerroomPrefabs[Random.Range(0, LowerroomPrefabs.Length)]; // �Ϲ� �� ������ ������ ����
        }
    }
    int RoomsPerFloor(int floor)
    {
        if (floor < 20) return 5;
        else if (floor < 40) return 4;
        else return 3;
    }
}
