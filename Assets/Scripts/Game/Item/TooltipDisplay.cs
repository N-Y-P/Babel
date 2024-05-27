using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TooltipDisplay : MonoBehaviour
{
    public static TooltipDisplay Instance { get; private set; }
    public GameObject tooltipUI; // 인스펙터에서 할당된 툴팁 UI

    [SerializeField]
    private TMP_Text nameText; // 아이템 이름을 표시할 텍스트
    [SerializeField]
    private TMP_Text descriptionText; // 아이템 설명을 표시할 텍스트

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowTooltip(Item item, Vector2 position)
    {
        if (tooltipUI != null)
        {
            tooltipUI.SetActive(true);
            RectTransform tooltipRectTransform = tooltipUI.GetComponent<RectTransform>();

            // 스크린 포인트를 캔버스 좌표로 변환
            Vector2 canvasPos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(tooltipRectTransform.parent as RectTransform, position, GetComponentInParent<Canvas>().worldCamera, out canvasPos);
            tooltipRectTransform.anchoredPosition = canvasPos; // 위치 설정

            UpdateTooltipUI(item);
        }
    }

    public void HideTooltip()
    {
        tooltipUI.SetActive(false);
    }

    private void UpdateTooltipUI(Item item)
    {
        if (item != null)
        {
            nameText.text = item.itemName; // 아이템 이름 업데이트
            descriptionText.text = item.itemDescription; // 아이템 설명 업데이트
        }
    }
}
