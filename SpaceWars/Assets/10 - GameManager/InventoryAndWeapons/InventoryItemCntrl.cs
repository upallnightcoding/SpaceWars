using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryItemCntrl : MonoBehaviour
{
    [SerializeField] private TMP_Text xp;
    [SerializeField] private Image image;

    // Start is called before the first frame update
    public void SetItem(InventoryItemSO item)
    {
        xp.text = item.xp.ToString();
        image.sprite = item.sprite;
    }
}
