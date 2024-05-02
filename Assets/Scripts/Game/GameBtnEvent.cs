using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBtnEvent : MonoBehaviour
{
    public GameObject tutorial;
    public GameObject bag;
    public GameObject battleScreen;
    public Tutorial tutorialScript; // Tutorial ��ũ��Ʈ
    public UIManager uiManager;

    public void CloseActiveWindow()
    {
        uiManager.CloseActiveWindow(); // UIManager�� ���� ���� Ȱ��ȭ�� â�� ����
    }
    public void TutoExit() // Ʃ�丮�� ����
    {
        tutorial.SetActive(false);
    }

    public void TutoNext() // ���� �������� �̵�
    {
        tutorialScript.IncrementPage(); 
    }

    public void TutoPrevious() // ���� �������� �̵�
    {
        tutorialScript.DecrementPage(); // ������ Tutorial ��ũ��Ʈ�� �ִ� �޼ҵ� �̸����� ����
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
