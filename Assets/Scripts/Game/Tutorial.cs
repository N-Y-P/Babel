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
            TutoContents[i].SetActive(i == currentPage);//i에 맞는 페이지 보여주기true
        }
    }

    public void UpdateButtons()
    {
        leftButton.SetActive(currentPage > 0);//현재 페이지가 0보다 크면 왼쪽 버튼 true
        rightButton.SetActive(currentPage < TutoContents.Length - 1);//현재 페이지가 배열 마지막이면 false
    }

    public void IncrementPage()
    {
        if (currentPage < TutoContents.Length - 1)
        {//현재 페이지가 마지막 페이지가 아니라면
            currentPage++;//오른쪽 버튼 눌렀을 때 페이지 증가
            UpdatePage();
            UpdateButtons();
        }
    }

    public void DecrementPage()
    {
        if (currentPage > 0)
        {//현재 페이지가 첫번째 페이지가 아니라면
            currentPage--;//왼쪽 버튼 눌렀을 때 페이지 감소 가능
            UpdatePage();
            UpdateButtons();
        }
    }
}
