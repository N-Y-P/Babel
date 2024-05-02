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
        TitleStartBtn.SetActive(false);  //시작버튼 비활성화

    }
    public void GoSkip()
    {
        SceneManager.LoadScene("Game");
    }
    public void GoNextPage()
    {
        cartoonNextPage.CartoonNext(); // 페이지 넘기기 함수 호출
    }
}
