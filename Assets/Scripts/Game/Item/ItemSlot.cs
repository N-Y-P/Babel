using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEditor.Progress;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Item item; // ȹ���� ������
    public bool isEquipmentSlot; // ��� �������� ���θ� ǥ��
    public ItemRecipe itemRecipe;//�ִ� ��츸 
    public Image itemImage; // �������� �̹���
    public int itemCount = 1; // ȹ���� �������� ����, �⺻�� 1

    [SerializeField]
    private TMP_Text text_Count; // UI Text ������Ʈ ����
    [SerializeField]
    private GameObject countImage; // ������ ǥ���ϴ� UI �̹��� ��ü

    void Start()
    {
        if (item != null)
        {
            UpdateSlotUI(); // �ʱ⿡ ���� UI�� ������Ʈ
        }
    }

    public void OnPointerClick(PointerEventData eventData) // Ŭ�� �̺�Ʈ ó��
    {
        if (itemRecipe != null)
        {
            RecipeFactory.Instance.UpdateCraftingUI(itemRecipe); // ������ ������ ���ۼ� UI�� ǥ��
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (isEquipmentSlot && item.itemType == Item.ItemType.Equipment)
            {
                ItemEquipManager.Instance.EquipItem(item);
            }
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Canvas canvas = GetComponentInParent<Canvas>(); // ������ �ִ� ĵ���� ã��
        RectTransform rectTransform = GetComponent<RectTransform>();
        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(canvas.worldCamera, rectTransform.position);
        Vector2 tooltipPosition = new Vector2(screenPoint.x, screenPoint.y + 200); // ���� ��ġ���� y������ ���� ������

        TooltipDisplay.Instance.ShowTooltip(item, tooltipPosition);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipDisplay.Instance.HideTooltip();
    }
    // �����۰� ������ �����ϰ� UI�� ������Ʈ�ϴ� �޼���
    public void SetItem(Item newItem)
    {
        item = newItem; // ������ ����
        itemCount = 1;  // �� �������� �߰��� �� ������ 1�� �ʱ�ȭ
        UpdateSlotUI();
    }

    // ������ ������ ������Ʈ�ϰ� UI�� �����ϴ� �޼���
    public void AddItemCount(int count)
    {
        itemCount += count;
        UpdateSlotUI();
    }

    // ������ UI�� ������Ʈ�ϴ� �޼���
    public void UpdateSlotUI()
    {
        itemImage.sprite = item.itemImage; // ������ �̹��� ����

        if (itemCount > 1)
        {
            text_Count.text = itemCount.ToString(); // ������ ���� �ؽ�Ʈ ����
            countImage.SetActive(true); // ������ 1���� Ŭ ���� ���� �̹��� Ȱ��ȭ
        }
        else
        {
            countImage.SetActive(false); // ������ 1�̸� ���� �̹��� ��Ȱ��ȭ
        }
    }
}
