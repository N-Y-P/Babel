using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  

public class FadeInOut : MonoBehaviour
{
    public TitleBtnEvent TitleBtnEvent;
    public Image FadeImage;  
    public float fadeDuration = 1.0f;  // ���̵尡 �Ϸ�Ǵ� �� �ɸ��� �ð�
    public float delayBetweenFades = 2.0f;  // ���̵� �ƿ��� ���̵� �� ������ ���� �ð�

    void Update()
    {
        if (TitleBtnEvent.FadeState)
        {
            StartCoroutine(FadeOutAndIn());
            TitleBtnEvent.FadeState = false;  // �� �� ���� �� �ٽ� �ʱ�ȭ
        }
    }
    IEnumerator FadeOutAndIn()
    {
        yield return StartCoroutine(FadeOut());  // ���̵� �ƿ� ����
        yield return new WaitForSeconds(delayBetweenFades);  // ����
        yield return StartCoroutine(FadeIn());  // ���̵� �� ����
    }
    IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        Color color = FadeImage.color;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);  // ���İ��� 0���� 1�� ����
            FadeImage.color = color;
            yield return null;
        }
        color.a = 1f;  // ������ �������ϰ�
        FadeImage.color = color;
    }
    IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        Color color = FadeImage.color;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            FadeImage.color = color;
            yield return null;
        }
        color.a = 0f;
        FadeImage.color = color;
    }
}
