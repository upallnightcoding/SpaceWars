using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryItemCntrl : MonoBehaviour
{
    [SerializeField] private TMP_Text xp;
    [SerializeField] private Image image;

    private InventoryItemSO inventoryItem;

    /**
     * SetItem() -
     */
    public void SetItem(InventoryItemSO inventoryItem)
    {
        this.inventoryItem = inventoryItem;

        xp.text = inventoryItem.xp.ToString();
        image.sprite = inventoryItem.sprite;
    }

    public void InventorySelect()
    {
        EventManager.Instance.InvokeOnInventorySelection(inventoryItem);
    }
}
