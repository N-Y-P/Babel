using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAni : MonoBehaviour
{
    public GameObject player;
    public float speed = 5f; // 이동 속도
    private SkeletonAnimation skeletonAnimation;
    public bool Moveable = true;//연속이동 시 오류 생성 방지용

    void Start()
    {
        skeletonAnimation = player.GetComponent<SkeletonAnimation>();
    }

    // targetPosition을 인자로 받아 움직임을 처리
    public void MoveToPosition(Vector3 targetPosition)
    {
        StartCoroutine(MovePlayer(targetPosition));
    }

    IEnumerator MovePlayer(Vector3 targetPosition)
    {
        // 애니메이션을 'walking'으로 변경
        skeletonAnimation.AnimationName = "walking";
        Moveable = false;//walking 애니메이션 출력될 때 다른 방 이동 불가
        while (Vector3.Distance(player.transform.position, targetPosition) > 0.01f)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;  // 다음 프레임까지 기다림
        }

        // 위치 이동 후 애니메이션을 'idle'로 변경
        skeletonAnimation.AnimationName = "idle";  // 원하는 대기 애니메이션 이름으로 변경
        Moveable = true;//이제 다른 방 클릭해서 이동 가능
    }
}
