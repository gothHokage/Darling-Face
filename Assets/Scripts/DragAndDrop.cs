using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    private RectTransform rectTransform;
    private Image item;

    private void Awake()
    {

        rectTransform = GetComponent<RectTransform>();
        item = GetComponent<Image>();

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        item.color = new Color(0f, 255f, 200f, 0.7f);
        item.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        item.color = new Color(255f, 255f, 255f, 1f);
        item.raycastTarget = true;
    }


}
