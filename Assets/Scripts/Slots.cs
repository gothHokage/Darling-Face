using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

    public class Slots : MonoBehaviour, IDropHandler
{
    
    public int countOfDrop = 0;
    public Bag Bg;


    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

                countOfDrop++;

        }
    }


    public void Update()
    {
        if (countOfDrop == 4)
        {
            Bg.Baggy.SetActive(false);
            Bg.BagIsOpen = false;
            Bg.Mono.SetActive(true);
        }

    }





}
