using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TooltipDisplay : MonoBehaviour
{
    public static TooltipDisplay Instance { get; private set; }
    public GameObject tooltipUI; // �ν����Ϳ��� �Ҵ�� ���� UI

    [SerializeField]
    private TMP_Text nameText; // ������ �̸��� ǥ���� �ؽ�Ʈ
    [SerializeField]
    private TMP_Text descriptionText; // ������ ������ ǥ���� �ؽ�Ʈ

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

            // ��ũ�� ����Ʈ�� ĵ���� ��ǥ�� ��ȯ
            Vector2 canvasPos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(tooltipRectTransform.parent as RectTransform, position, GetComponentInParent<Canvas>().worldCamera, out canvasPos);
            tooltipRectTransform.anchoredPosition = canvasPos; // ��ġ ����

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
            nameText.text = item.itemName; // ������ �̸� ������Ʈ
            descriptionText.text = item.itemDescription; // ������ ���� ������Ʈ
        }
    }
}
