using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryItemCntrl : MonoBehaviour
{
    [SerializeField] private TMP_Text xp;
    [SerializeField] private Image image;
    [SerializeField] private TMP_Text description;
    [SerializeField] private GameObject notSelectableBG;

    public bool IsInventory { get; set; } = true;

    private Transform inventoryCollection;
    private Transform weaponsCollection;

    private InventoryItemSO inventoryItem;

    /**
     * SetItem() -
     */
    public void SetItem(
        InventoryItemSO inventoryItem,
        GameObject inventoryCollection,
        GameObject weaponsCollection
    )
    {
        this.inventoryItem = inventoryItem;
        this.inventoryCollection = inventoryCollection.transform;
        this.weaponsCollection = weaponsCollection.transform;

        transform.SetParent(this.inventoryCollection);

        IsInventory = true;

        xp.text = inventoryItem.xp.ToString();
        image.sprite = inventoryItem.sprite;
        description.text = inventoryItem.description;
    }

    public void IsSelectable(long xpAmt)
    {
        if (inventoryItem.xp > xpAmt)
        {
            notSelectableBG.SetActive(false);
        } else
        {
            notSelectableBG.SetActive(true);
        }
    }

    /**
     * SwitchInventory() -
     */
    public void SwitchInventory()
    {
        EventManager.Instance.InvokeOnUpdateXP(inventoryItem.xp * (IsInventory ? -1 : 1));

        IsInventory = !IsInventory;

        transform.SetParent(IsInventory ? inventoryCollection : weaponsCollection);
    }

    /**
     * InventorySelect() - This is part of a UI element and is invoked when
     * the player selects the inventory item as a UI button.  The inventory
     * item has no handles into the UI structure so therefore must invoke an
     * event to notify that a selection has been made.
     */
    public void InventorySelect()
    {
        EventManager.Instance.InvokeOnInventorySelection(inventoryItem);
    }
}
