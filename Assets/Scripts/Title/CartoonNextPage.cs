using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CartoonNextPage : MonoBehaviour
{
    public Image FadeImage;
    public GameObject Cartoons;
    public GameObject[] Cut;
    public GameObject SkipBtn;
    private int currentPage = 0; 
    // Update is called once per frame
    void Update()
    {
        CartoonsOpen();
    }
    //���� ȭ���� ������� cartoons ������Ʈ Ȱ��ȭ
    public void CartoonsOpen()
    {
        Color color = FadeImage.color;
        if (color.a == 1f)
        {
            Cartoons.SetActive(true);
        }
        else
        {
            StartCoroutine(SkipBtnDelay(5.2f));
        }
    }
    private IEnumerator SkipBtnDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SkipBtn.SetActive(true);
    }
    public void CartoonNext()
    {
        if (currentPage < Cut.Length - 1)
        {
            Cut[currentPage].SetActive(false);
            currentPage++;
            Cut[currentPage].SetActive(true);
        }
        else
        {
            SceneManager.LoadScene("Game");
        }

    }

}
