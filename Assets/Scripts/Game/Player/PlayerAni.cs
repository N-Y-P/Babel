using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAni : MonoBehaviour
{
    public GameObject player;
    public float speed = 5f; // �̵� �ӵ�
    private SkeletonAnimation skeletonAnimation;
    public bool Moveable = true;//�����̵� �� ���� ���� ������

    void Start()
    {
        skeletonAnimation = player.GetComponent<SkeletonAnimation>();
    }

    // targetPosition�� ���ڷ� �޾� �������� ó��
    public void MoveToPosition(Vector3 targetPosition)
    {
        StartCoroutine(MovePlayer(targetPosition));
    }

    IEnumerator MovePlayer(Vector3 targetPosition)
    {
        // �ִϸ��̼��� 'walking'���� ����
        skeletonAnimation.AnimationName = "walking";
        Moveable = false;//walking �ִϸ��̼� ��µ� �� �ٸ� �� �̵� �Ұ�
        while (Vector3.Distance(player.transform.position, targetPosition) > 0.01f)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;  // ���� �����ӱ��� ��ٸ�
        }

        // ��ġ �̵� �� �ִϸ��̼��� 'idle'�� ����
        skeletonAnimation.AnimationName = "idle";  // ���ϴ� ��� �ִϸ��̼� �̸����� ����
        Moveable = true;//���� �ٸ� �� Ŭ���ؼ� �̵� ����
    }
}
