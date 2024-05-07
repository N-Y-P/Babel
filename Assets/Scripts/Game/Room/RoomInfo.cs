using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomInfo : MonoBehaviour
{
    //방이 가지고 있는 정보
    public int RoomNumber; //방 넘버
    public int CurrenFloor; //현재 층
    public Transform point1;
    public Transform point2;
    public Transform Enemy;

    //방의 hide를 누르게 되면 플레이어는 그 방의 층, 방 넘버, 그 방에 서있는 point 정보를 가지게 됨
    //그 다음 방의 hide를 누르게 되면 플레이어는 그 방의 동일한 정보를 배열 그 다음 인덱스에 넣음
    //[(1층, 2번방, point1), ()] -> [(), (1층, 3번방, point1)]
    //[0][1]의 값이 [1][1]의 값 비교 , 만약 층수가 같고, 1번 인덱스의 숫자가 더 크면 [2]의 값을 동일하게,
    //(2층, 6번방, point1)->(1층, 5번방, point2)
    //만약 층수가 낮아지면, 계단을 지나게 될텐데 계단의 point값을 가져옴
    //계단이 point2을 가지고 있으면 (1층, 5번방,point2)
    //만약 층수가 높아지면,
    //(1층, 5번 방, point1) -> (2층, 6번 방, point2)

    //플레이어가 가져야 하는 것
    //이동메소드, 이동할 때 애니메이션, 상태 정보(hp, exp등), 
}
