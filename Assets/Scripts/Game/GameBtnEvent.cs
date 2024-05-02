using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBtnEvent : MonoBehaviour
{
    public GameObject tutorial;
    public GameObject bag;
    public GameObject battleScreen;
    public Tutorial tutorialScript; // Tutorial 스크립트
    public UIManager uiManager;

    public void CloseActiveWindow()
    {
        uiManager.CloseActiveWindow(); // UIManager를 통해 현재 활성화된 창을 닫음
    }
    public void TutoExit() // 튜토리얼 끄기
    {
        tutorial.SetActive(false);
    }

    public void TutoNext() // 다음 페이지로 이동
    {
        tutorialScript.IncrementPage(); 
    }

    public void TutoPrevious() // 이전 페이지로 이동
    {
        tutorialScript.DecrementPage(); // 실제로 Tutorial 스크립트에 있는 메소드 이름으로 변경
    }

    public void BagOn()
    {
        bag.SetActive(true);
    }
    public void BattleScreenOn()
    {
        battleScreen.SetActive(true);
    }
}
