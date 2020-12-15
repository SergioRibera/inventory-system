using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ItemObject : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [ReadOnly] public int index, id;
    public bool Interactable = true;
    public PositionDialog positionDialog;
    public GameObject[] dialogs;
    public Color selected, click, hover, natural;

    public event Action<int> onClick;
    
    ShopManager shopManager;
    string desc = "";
    public void SetTextToHover(int ind, int id, ShopManager sm, string content, string d){
        this.id = id;
        index = ind;
        shopManager = sm;
        desc = d;
        foreach(var dialog in dialogs){
            dialog.GetComponentInChildren<TextMeshProUGUI>().text = content;
            dialog.SetActive(false);
        }
        Interactable = true;
    }

    public void OnPointerEnter(PointerEventData pointerEventData){
        if(Interactable){
            dialogs[(int)positionDialog].SetActive(true);
            shopManager.ShowDialog(desc);
        }
    }
    public void OnPointerExit(PointerEventData pointerEventData) =>
            dialogs[(int)positionDialog].SetActive(false);

    public void OnPointerClick(PointerEventData pointerEventData){
        if(Interactable){
            onClick?.Invoke(index);
            GetComponent<Image>().color = shopManager.itemsOffer[index].selected ? selected : natural;
        }
    }
}
