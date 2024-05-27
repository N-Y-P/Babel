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
    public Tutorial tutorialScript; // Tutorial ��ũ��Ʈ

    [Header("�κ��丮 ������")]
    public Button[] buttons; // ��� ��ư�� ����
    public GameObject[] recipes;//�����ǵ�
    public Color activeColor; // Ȱ��ȭ ��
    public Color inactiveColor; // ��Ȱ��ȭ ��

    public UIManager uiManager;
    public GameObject TransparentWall;

    public void CloseActiveWindow()
    {
        uiManager.CloseActiveWindow(); // UIManager�� ���� ���� Ȱ��ȭ�� â�� ����
        TransparentWall.SetActive(false);
    }
    #region Ʃ�丮��
    public void TutoExit() // Ʃ�丮�� ����
    {
        tutorial.SetActive(false);
        TransparentWall.SetActive(false);
        bagbtn.SetActive(true);
    }

    public void TutoNext() // ���� �������� �̵�
    {
        tutorialScript.IncrementPage(); 
    }

    public void TutoPrevious() // ���� �������� �̵�
    {
        tutorialScript.DecrementPage(); // ������ Tutorial ��ũ��Ʈ�� �ִ� �޼ҵ� �̸����� ����
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
    //�� ���� ��ư �߿��� 
    //���� ��ư ������ ����� �߰�, ������ �� ��Ȱ��ȭ
    //��ư ������ 
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
                SetButtonColor(btn, activeColor); // Ŭ���� ��ư�� Ȱ��ȭ ����
            }
            else
            {
                SetButtonColor(btn, inactiveColor); // �ٸ� ��ư�� ��Ȱ��ȭ ����
            }
        }
    }

    void SetButtonColor(Button button, Color color)
    {
        Image image = button.GetComponentInChildren<Image>(); // Button�� �ڽĿ��� Image ������Ʈ ã��
        if (image != null)
        {
            image.color = color; // Image�� ���� ����
        }
    }
}
