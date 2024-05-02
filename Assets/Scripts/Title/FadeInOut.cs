using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  

public class FadeInOut : MonoBehaviour
{
    public TitleBtnEvent TitleBtnEvent;
    public Image FadeImage;  
    public float fadeDuration = 1.0f;  // 페이드가 완료되는 데 걸리는 시간
    public float delayBetweenFades = 2.0f;  // 페이드 아웃과 페이드 인 사이의 지연 시간

    void Update()
    {
        if (TitleBtnEvent.FadeState)
        {
            StartCoroutine(FadeOutAndIn());
            TitleBtnEvent.FadeState = false;  // 한 번 실행 후 다시 초기화
        }
    }
    IEnumerator FadeOutAndIn()
    {
        yield return StartCoroutine(FadeOut());  // 페이드 아웃 실행
        yield return new WaitForSeconds(delayBetweenFades);  // 지연
        yield return StartCoroutine(FadeIn());  // 페이드 인 실행
    }
    IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        Color color = FadeImage.color;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);  // 알파값을 0에서 1로 변경
            FadeImage.color = color;
            yield return null;
        }
        color.a = 1f;  // 완전히 불투명하게
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
