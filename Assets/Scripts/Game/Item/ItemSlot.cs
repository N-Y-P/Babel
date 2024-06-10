using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEditor.Progress;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Item item; // 획득한 아이템
    public bool isEquipmentSlot; // 장비 슬롯인지 여부를 표시
    public ItemRecipe itemRecipe;//있는 경우만 
    public Image itemImage; // 아이템의 이미지
    public int itemCount = 1; // 획득한 아이템의 개수, 기본값 1

    [SerializeField]
    private TMP_Text text_Count; // UI Text 컴포넌트 참조
    [SerializeField]
    private GameObject countImage; // 수량을 표시하는 UI 이미지 객체

    void Start()
    {
        if (item != null)
        {
            UpdateSlotUI(); // 초기에 슬롯 UI를 업데이트
        }
    }

    public void OnPointerClick(PointerEventData eventData) // 클릭 이벤트 처리
    {
        if (itemRecipe != null)
        {
            RecipeFactory.Instance.UpdateCraftingUI(itemRecipe); // 레시피 정보를 제작소 UI에 표시
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
        Canvas canvas = GetComponentInParent<Canvas>(); // 슬롯이 있는 캔버스 찾기
        RectTransform rectTransform = GetComponent<RectTransform>();
        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(canvas.worldCamera, rectTransform.position);
        Vector2 tooltipPosition = new Vector2(screenPoint.x, screenPoint.y + 200); // 슬롯 위치에서 y축으로 조금 오프셋

        TooltipDisplay.Instance.ShowTooltip(item, tooltipPosition);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipDisplay.Instance.HideTooltip();
    }
    // 아이템과 수량을 설정하고 UI를 업데이트하는 메서드
    public void SetItem(Item newItem)
    {
        item = newItem; // 아이템 설정
        itemCount = 1;  // 새 아이템을 추가할 때 수량을 1로 초기화
        UpdateSlotUI();
    }

    // 아이템 수량을 업데이트하고 UI를 갱신하는 메서드
    public void AddItemCount(int count)
    {
        itemCount += count;
        UpdateSlotUI();
    }

    // 슬롯의 UI를 업데이트하는 메서드
    public void UpdateSlotUI()
    {
        itemImage.sprite = item.itemImage; // 아이템 이미지 갱신

        if (itemCount > 1)
        {
            text_Count.text = itemCount.ToString(); // 아이템 수량 텍스트 갱신
            countImage.SetActive(true); // 수량이 1보다 클 때만 수량 이미지 활성화
        }
        else
        {
            countImage.SetActive(false); // 수량이 1이면 수량 이미지 비활성화
        }
    }
}
