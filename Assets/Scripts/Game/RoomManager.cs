using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public static RoomManager Instance;
    public List<RoomInfo> allRooms = new List<RoomInfo>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RegisterRoom(RoomInfo roomInfo)
    {
        allRooms.Add(roomInfo);
    }
}
