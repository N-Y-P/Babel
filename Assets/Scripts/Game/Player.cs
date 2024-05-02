using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    //플레이어 오브젝트 받기
    public GameObject player;
    //플레이어 포지션 받기

    //포인트 1, 2 포지션 받기
    public Transform point1;
    public Transform point2;
    //버튼 이벤트(누르면 이동)
    public float speed = 5f;         // 이동 속도
    private SkeletonAnimation skeletonAnimation;

    void Start()
    {
        skeletonAnimation = player.GetComponent<SkeletonAnimation>();
    }
    public void MoveToPosition()
    {
        StartCoroutine(MovePlayer(point2.position));
    }

    IEnumerator MovePlayer(Vector3 targetPosition)
    {
        // 애니메이션을 'walking'으로 변경
        skeletonAnimation.AnimationName = "walking";

        while (Vector3.Distance(player.transform.position, targetPosition) > 0.01f)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;  // 다음 프레임까지 기다림
        }

        // 위치 이동 후 애니메이션 변경
        skeletonAnimation.AnimationName = "idle";  // 원하는 대기 애니메이션 이름으로 변경
    }
    //버튼을 누르면 포인트 1에서 2로 오브젝트가 이동하면서 walk 애니메이션 발동
}
