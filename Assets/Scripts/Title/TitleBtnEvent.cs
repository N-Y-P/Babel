using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleBtnEvent : MonoBehaviour
{
    public bool FadeState = false;
    public GameObject TitleStartBtn;
    public GameObject ContinueBtn;
    public GameObject EndBtn;
    public CartoonNextPage cartoonNextPage;

    public void GameStart()
    {
        FadeState = true;
        TitleStartBtn.SetActive(false);  //���۹�ư ��Ȱ��ȭ
        ContinueBtn.SetActive(false);
        EndBtn.SetActive(false);

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
