using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject[] TutoContents;
    public GameObject leftButton, rightButton;
    public int currentPage = 0;

    void Start()
    {
        UpdateButtons();
        UpdatePage();
    }

    public void UpdatePage()
    {
        for (int i = 0; i < TutoContents.Length; i++)
        {
            TutoContents[i].SetActive(i == currentPage);//i�� �´� ������ �����ֱ�true
        }
    }

    public void UpdateButtons()
    {
        leftButton.SetActive(currentPage > 0);//���� �������� 0���� ũ�� ���� ��ư true
        rightButton.SetActive(currentPage < TutoContents.Length - 1);//���� �������� �迭 �������̸� false
    }

    public void IncrementPage()
    {
        if (currentPage < TutoContents.Length - 1)
        {//���� �������� ������ �������� �ƴ϶��
            currentPage++;//������ ��ư ������ �� ������ ����
            UpdatePage();
            UpdateButtons();
        }
    }

    public void DecrementPage()
    {
        if (currentPage > 0)
        {//���� �������� ù��° �������� �ƴ϶��
            currentPage--;//���� ��ư ������ �� ������ ���� ����
            UpdatePage();
            UpdateButtons();
        }
    }
}
