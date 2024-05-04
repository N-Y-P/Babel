using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class TowerGenerator : MonoBehaviour
{
    public GameObject[] LowerroomPrefabs; // 방 프리팹 배열
    public int floors = 20;          // 층 수
    public int roomsPerFloor = 5;    // 층 당 방 수
    public float roomWidth = 10f;    // 방 너비
    public float roomHeight = 8f;    // 방 높이
    public float roomSpacing = 1.0f;  // 방 사이의 추가 간격
    public float roomup = 2.9f;  // 방 사이의 추가 간격
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
                // floor가 짝수인 경우 왼쪽에서 오른쪽으로, 홀수인 경우 오른쪽에서 왼쪽으로 방을 생성
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
                // 각 방의 x 위치를 계산할 때 간격을 고려
                Vector3 position = new Vector3(index * (roomSpacing), floor * (roomup), 0);
                GameObject roomPrefab = LowerroomPrefabs[Random.Range(0, LowerroomPrefabs.Length)];
                GameObject roomInstance = Instantiate(roomPrefab, position, Quaternion.identity);

                // RoomInfo 컴포넌트 설정
                RoomInfo roomInfo = roomInstance.GetComponent<RoomInfo>();
                if (roomInfo == null)
                {
                    roomInfo = roomInstance.AddComponent<RoomInfo>(); // RoomInfo 컴포넌트가 없으면 추가
                }
                roomnum++;
                roomInfo.RoomNumber = roomnum;  // 방 번호 설정
                roomInfo.CurrenFloor = floor + 1;  // 층 번호 설정
            }
        }
    }
}
