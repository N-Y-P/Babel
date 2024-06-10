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
    public RecipeFactory recipeFactory;// RecipeFactory 스크립트

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
    #region 인벤토리 속 무기,체력회복,정신회복 버튼들의 관계
    public void equipment_Recipes()
    {
        recipes[0].SetActive(true);
        recipes[1].SetActive(false);
        recipes[2].SetActive(false);
        recipeFactory.AllSetfalse();
    }
    public void hp_medicine_Recipes()
    {
        recipes[0].SetActive(false);
        recipes[1].SetActive(true);
        recipes[2].SetActive(false);
        recipeFactory.AllSetfalse();
    }
    public void mental_medicine_Recipes()
    {
        recipes[0].SetActive(false);
        recipes[1].SetActive(false);
        recipes[2].SetActive(true);
        recipeFactory.AllSetfalse();
    }
    #endregion

    /*****테스트용 메소드. 추후 삭제****/
    public Player player;  // Player 컴포넌트를 할당할 공개 필드
    public GameObject Card;
    // 체력을 감소시키는 메소드
    public void DecreaseHealth()//적 공격, 약 효과
    {
        if (player != null)
        {
            player.CurrentHP -= 10;
        }
    }
    // 경험치를 증가시키는 메소드
    public void IncreaseExperience()
    {
        if (player != null)
        {
            player.CurrentExp += 100;
            
            if (player.CurrentExp >= player.ExpRequired)
            {
                //카드 생성로직
                Card.SetActive(true);
                //player.current_exp = 0;  // 경험치를 초과하면 초기화 (레벨업 로직 구현 가능)
            }
            
        }
    }
    /*****추후 삭제****/


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
