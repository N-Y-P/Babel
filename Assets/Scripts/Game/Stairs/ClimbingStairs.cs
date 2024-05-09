using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbingStairs : MonoBehaviour
{
    #region
    //�÷��̾ ���� �̵��� �� 
    //��� �̿� ���� ���
    //�� ��ũ��Ʈ�� PlayerMovement���� ����

    //(�ö�) ���� ���� ���� ���̰� ���� ���� �� ���϶�(1->2��)
    //������ ��ġ�ϴ� ��� �������� ã��
    //point 1 -> point 2 -> 180�� ȸ�� -> point 3 - > ���� ���� ��ġ��

    //(������) �� ���� ���� ���̰� ���� ���� ���� ���� ��
    //������ ��ġ�ϴ� ��� �������� ã��
    //point3 -> point2 -> 180�� ȸ�� -> point 1 -> ���� ���� ��ġ��
    #endregion

    public Transform playerTransform; // �÷��̾��� Transform ����
    public float speed = 3.0f; // ����� �����ų� ������ �ӵ�

    // �÷��̾ ����� ������ �޼ҵ�
    public IEnumerator ClimbUpStairs(StairInfo stair)
    {
        // ��� ������ �ִϸ��̼� ����
        // ��: playerAni.SetAnimation("climbUp");

        // ����� �������� ���� �÷��̾ �̵� (0 -> 1 -> 2)
        for (int i = 0; i < stair.Positions.Length; i++)
        {
            Vector3 nextPosition = stair.Positions[i].position;
            while (playerTransform.position != nextPosition)
            {
                playerTransform.position = Vector3.MoveTowards(playerTransform.position, nextPosition, speed * Time.deltaTime);
                yield return null;
            }
        }

        // �̵� �Ϸ� �� ��� �ִϸ��̼����� ��ȯ
        // ��: playerAni.SetAnimation("idle");
    }

    // �÷��̾ ����� ������ �޼ҵ�
    public IEnumerator ClimbDownStairs(StairInfo stair)
    {
        // ��� ������ �ִϸ��̼� ����
        // ��: playerAni.SetAnimation("climbDown");

        // ����� �������� ���� �÷��̾ �̵� (2 -> 1 -> 0)
        for (int i = stair.Positions.Length - 1; i >= 0; i--)
        {
            Vector3 nextPosition = stair.Positions[i].position;
            while (playerTransform.position != nextPosition)
            {
                playerTransform.position = Vector3.MoveTowards(playerTransform.position, nextPosition, speed * Time.deltaTime);
                yield return null;
            }
        }

        // �̵� �Ϸ� �� ��� �ִϸ��̼����� ��ȯ
        // ��: playerAni.SetAnimation("idle");
    }
    public StairInfo FindStair(int currentFloor, int targetFloor)
    {
        StairInfo[] allStairs = FindObjectsOfType<StairInfo>(); // ��� StairInfo ������Ʈ�� ã��
        foreach (StairInfo stair in allStairs)
        {
            // ������ ���� ������ ��� ��� �˻�
            if ((stair.StartFloor == currentFloor && stair.EndFloor == targetFloor) ||
                (stair.StartFloor == targetFloor && stair.EndFloor == currentFloor))
            {
                return stair;
            }
        }
        return null; // ������ ����� ã�� ������ ��� null ��ȯ
    }
}
