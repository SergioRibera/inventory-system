using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ItemObject : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [ReadOnly] public int index;
    public PositionDialog positionDialog;
    public GameObject[] dialogs;
    public Color selected, click, hover, natural;

    public event Action<int> onClick;
    
    ShopManager shopManager;
    public void SetTextToHover(int ind, ShopManager sm, string content){
        index = ind;
        shopManager = sm;
        foreach(var dialog in dialogs){
            dialog.GetComponentInChildren<TextMeshProUGUI>().text = content;
            dialog.SetActive(false);
        }
    }

    public void OnPointerEnter(PointerEventData pointerEventData) =>
        dialogs[(int)positionDialog].SetActive(true);
    public void OnPointerExit(PointerEventData pointerEventData) =>
        dialogs[(int)positionDialog].SetActive(false);

    public void OnPointerClick(PointerEventData pointerEventData){
        onClick?.Invoke(index);
        GetComponent<Image>().color = shopManager.itemsOffer[index].selected ? selected : natural;
    }
}
