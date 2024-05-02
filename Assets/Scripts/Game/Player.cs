using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    //�÷��̾� ������Ʈ �ޱ�
    public GameObject player;
    //�÷��̾� ������ �ޱ�

    //����Ʈ 1, 2 ������ �ޱ�
    public Transform point1;
    public Transform point2;
    //��ư �̺�Ʈ(������ �̵�)
    public float speed = 5f;         // �̵� �ӵ�
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
        // �ִϸ��̼��� 'walking'���� ����
        skeletonAnimation.AnimationName = "walking";

        while (Vector3.Distance(player.transform.position, targetPosition) > 0.01f)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;  // ���� �����ӱ��� ��ٸ�
        }

        // ��ġ �̵� �� �ִϸ��̼� ����
        skeletonAnimation.AnimationName = "idle";  // ���ϴ� ��� �ִϸ��̼� �̸����� ����
    }
    //��ư�� ������ ����Ʈ 1���� 2�� ������Ʈ�� �̵��ϸ鼭 walk �ִϸ��̼� �ߵ�
}
