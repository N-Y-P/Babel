using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleBtnEvent : MonoBehaviour
{
    public bool FadeState = false;
    public GameObject TitleStartBtn;
    public CartoonNextPage cartoonNextPage;

    public void GameStart()
    {
        FadeState = true;
        TitleStartBtn.SetActive(false);  //���۹�ư ��Ȱ��ȭ

    }
    public void GoSkip()
    {
        SceneManager.LoadScene("Game");
    }
    public void GoNextPage()
    {
        cartoonNextPage.CartoonNext(); // ������ �ѱ�� �Լ� ȣ��
    }
}
