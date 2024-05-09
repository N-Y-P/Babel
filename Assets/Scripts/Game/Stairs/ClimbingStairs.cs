using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbingStairs : MonoBehaviour
{
    #region
    //플레이어가 층을 이동할 때 
    //계단 이용 로직 기술
    //이 스크립트는 PlayerMovement에서 사용됨

    //(올라감) 시작 층이 현재 층이고 누른 층이 끝 층일때(1->2층)
    //정보가 일치하는 계단 프리팹을 찾음
    //point 1 -> point 2 -> 180도 회전 -> point 3 - > 누른 방의 위치로

    //(내려감) 끝 층이 현재 층이고 누른 층이 시작 층일 때
    //정보가 일치하는 계단 프리팹을 찾음
    //point3 -> point2 -> 180도 회전 -> point 1 -> 누른 방의 위치로
    #endregion

    public Transform playerTransform; // 플레이어의 Transform 참조
    public float speed = 3.0f; // 계단을 오르거나 내리는 속도

    // 플레이어가 계단을 오르는 메소드
    public IEnumerator ClimbUpStairs(StairInfo stair)
    {
        // 계단 오르기 애니메이션 실행
        // 예: playerAni.SetAnimation("climbUp");

        // 계단의 포지션을 따라 플레이어를 이동 (0 -> 1 -> 2)
        for (int i = 0; i < stair.Positions.Length; i++)
        {
            Vector3 nextPosition = stair.Positions[i].position;
            while (playerTransform.position != nextPosition)
            {
                playerTransform.position = Vector3.MoveTowards(playerTransform.position, nextPosition, speed * Time.deltaTime);
                yield return null;
            }
        }

        // 이동 완료 후 대기 애니메이션으로 전환
        // 예: playerAni.SetAnimation("idle");
    }

    // 플레이어가 계단을 내리는 메소드
    public IEnumerator ClimbDownStairs(StairInfo stair)
    {
        // 계단 내리기 애니메이션 실행
        // 예: playerAni.SetAnimation("climbDown");

        // 계단의 포지션을 따라 플레이어를 이동 (2 -> 1 -> 0)
        for (int i = stair.Positions.Length - 1; i >= 0; i--)
        {
            Vector3 nextPosition = stair.Positions[i].position;
            while (playerTransform.position != nextPosition)
            {
                playerTransform.position = Vector3.MoveTowards(playerTransform.position, nextPosition, speed * Time.deltaTime);
                yield return null;
            }
        }

        // 이동 완료 후 대기 애니메이션으로 전환
        // 예: playerAni.SetAnimation("idle");
    }
    public StairInfo FindStair(int currentFloor, int targetFloor)
    {
        StairInfo[] allStairs = FindObjectsOfType<StairInfo>(); // 모든 StairInfo 오브젝트를 찾음
        foreach (StairInfo stair in allStairs)
        {
            // 오르는 경우와 내리는 경우 모두 검사
            if ((stair.StartFloor == currentFloor && stair.EndFloor == targetFloor) ||
                (stair.StartFloor == targetFloor && stair.EndFloor == currentFloor))
            {
                return stair;
            }
        }
        return null; // 적절한 계단을 찾지 못했을 경우 null 반환
    }
}
