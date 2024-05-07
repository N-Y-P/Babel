using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbingStairs : MonoBehaviour
{
    //플레이어가 층을 이동할 때 
    //계단 이용 로직 기술
    //이 스크립트는 PlayerMovement에서 사용됨

    //(올라감) 시작 층이 현재 층이고 누른 층이 끝 층일때
    //정보가 일치하는 계단 프리팹의 이름에 Stair2가 있다면
    //point 1 -> point 2 -> 180도 회전 -> point 3 - > 누른 방의 point2
    //Stair1이 있다면
    //point 1 - > point 2 -> 180도 회전 -> point 3 -> 누른 방의 point1

    //(내려감) 끝 층이 현재 층이고 누른 층이 시작 층일 때
    //정보가 일치하는 계단 프리팹의 이름에 Stair2가 있다면
    //point3 -> point2 -> 180도 회전 -> point 1 -> 누른 방의 point2
    //Stiar1이 있다면
    //point3 -> point2 -> 180도 회전 -> point 1 -> 누른 방의 point1


}
