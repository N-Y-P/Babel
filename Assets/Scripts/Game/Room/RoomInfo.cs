using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomInfo : MonoBehaviour
{
    //���� ������ �ִ� ����
    public int RoomNumber; //�� �ѹ�
    public int CurrenFloor; //���� ��
    public Transform point1;
    public Transform point2;
    public Transform Enemy;

    //���� hide�� ������ �Ǹ� �÷��̾�� �� ���� ��, �� �ѹ�, �� �濡 ���ִ� point ������ ������ ��
    //�� ���� ���� hide�� ������ �Ǹ� �÷��̾�� �� ���� ������ ������ �迭 �� ���� �ε����� ����
    //[(1��, 2����, point1), ()] -> [(), (1��, 3����, point1)]
    //[0][1]�� ���� [1][1]�� �� �� , ���� ������ ����, 1�� �ε����� ���ڰ� �� ũ�� [2]�� ���� �����ϰ�,
    //(2��, 6����, point1)->(1��, 5����, point2)
    //���� ������ ��������, ����� ������ ���ٵ� ����� point���� ������
    //����� point2�� ������ ������ (1��, 5����,point2)
    //���� ������ ��������,
    //(1��, 5�� ��, point1) -> (2��, 6�� ��, point2)

    //�÷��̾ ������ �ϴ� ��
    //�̵��޼ҵ�, �̵��� �� �ִϸ��̼�, ���� ����(hp, exp��), 
}
