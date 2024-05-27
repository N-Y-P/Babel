using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameBtnEvent : MonoBehaviour
{
    public GameObject tutorial;
    public GameObject bag;
    public GameObject bagbtn;
    public GameObject battleScreen;
    public Tutorial tutorialScript; // Tutorial 스크립트

    [Header("인벤토리 레시피")]
    public Button[] buttons; // 모든 버튼을 참조
    public GameObject[] recipes;//레시피들
    public Color activeColor; // 활성화 색
    public Color inactiveColor; // 비활성화 색

    public UIManager uiManager;
    public GameObject TransparentWall;

    public void CloseActiveWindow()
    {
        uiManager.CloseActiveWindow(); // UIManager를 통해 현재 활성화된 창을 닫음
        TransparentWall.SetActive(false);
    }
    #region 튜토리얼
    public void TutoExit() // 튜토리얼 끄기
    {
        tutorial.SetActive(false);
        TransparentWall.SetActive(false);
        bagbtn.SetActive(true);
    }

    public void TutoNext() // 다음 페이지로 이동
    {
        tutorialScript.IncrementPage(); 
    }

    public void TutoPrevious() // 이전 페이지로 이동
    {
        tutorialScript.DecrementPage(); // 실제로 Tutorial 스크립트에 있는 메소드 이름으로 변경
    }
    #endregion
    public void BagOn()
    {
        bag.SetActive(true);
        TransparentWall.SetActive(true);
    }

    public void BattleScreenOn()
    {
        battleScreen.SetActive(true);
        TransparentWall.SetActive(true);
    }
    //세 개의 버튼 중에서 
    //무기 버튼 누르면 무기란 뜨고, 나머지 란 비활성화
    //버튼 색깔은 
    public void equipment_Recipes()
    {
        recipes[0].SetActive(true);
        recipes[1].SetActive(false);
        recipes[2].SetActive(false);
    }
    public void hp_medicine_Recipes()
    {
        recipes[0].SetActive(false);
        recipes[1].SetActive(true);
        recipes[2].SetActive(false);
    }
    public void mental_medicine_Recipes()
    {
        recipes[0].SetActive(false);
        recipes[1].SetActive(false);
        recipes[2].SetActive(true);
    }
    public void OnButtonClicked(Button clickedButton)
    {
        foreach (Button btn in buttons)
        {
            if (btn == clickedButton)
            {
                SetButtonColor(btn, activeColor); // 클릭된 버튼은 활성화 색상
            }
            else
            {
                SetButtonColor(btn, inactiveColor); // 다른 버튼은 비활성화 색상
            }
        }
    }

    void SetButtonColor(Button button, Color color)
    {
        Image image = button.GetComponentInChildren<Image>(); // Button의 자식에서 Image 컴포넌트 찾기
        if (image != null)
        {
            image.color = color; // Image의 색상 변경
        }
    }
}
