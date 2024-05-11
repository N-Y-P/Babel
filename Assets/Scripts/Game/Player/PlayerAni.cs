using Spine.Unity;
using System;
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
    public CameraMove cameraMove;

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
    
    public IEnumerator MoveAlongPath(Vector3[] positions, float[] rotations, Action onComplete)
    {
        for (int i = 0; i < positions.Length; i++)
        {
            // �ȴ� �ִϸ��̼� ����
            skeletonAnimation.AnimationName = "walking";

            // �÷��̾ ��ǥ ��ġ�� �̵�
            while (Vector3.Distance(player.transform.position, positions[i]) > 0.01f)
            {
                player.transform.position = Vector3.MoveTowards(player.transform.position, positions[i], speed * Time.deltaTime);
                yield return null;
            }

            // �÷��̾ ��ġ�� ������ �� ȸ���� ī�޶� ������Ʈ
            player.transform.eulerAngles = new Vector3(0, rotations[i], 0);
            UpdateCamera(rotations[i]); // ȸ���� ���� ������ ī�޶� ����
        }

        // �̵� �Ϸ� �� ��� �ִϸ��̼����� ����
        skeletonAnimation.AnimationName = "idle";
        onComplete(); // �ݹ� �Լ� ȣ��
    }
    
    private void UpdateCamera(float rotation)
    {
        if (rotation == 0)
        {
            cameraMove.VirtualCamera2(); // 0���� �� VirtualCamera2 Ȱ��ȭ
        }
        else
        {
            cameraMove.VirtualCamera1(); // 180���� �� VirtualCamera1 Ȱ��ȭ
        }
    }
    
    

}
