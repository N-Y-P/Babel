using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Transform canvasTransform; // Canvas�ޱ�

    // ���� Ȱ��ȭ�� â�� ��Ȱ��ȭ�ϴ� �޼ҵ�
    //GameBtnEvent���� ������
    public void CloseActiveWindow()
    {
        // Canvas�� ��� �ڽ��� �˻�, Ȱ��ȭ�� â�� ã�� ��Ȱ��ȭ
        foreach (Transform child in canvasTransform)
        {
            if (child.gameObject.activeSelf)
            {
                child.gameObject.SetActive(false);
                break; // ù ��° Ȱ��ȭ�� â�� ��Ȱ��ȭ �� �� ���� ����
            }
        }
    }
}