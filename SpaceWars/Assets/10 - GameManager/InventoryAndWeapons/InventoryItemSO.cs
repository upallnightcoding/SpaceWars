using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName = "InventoryItem", menuName = "Space Wars/Inventory Item")]
public class InventoryItemSO : ScriptableObject
{
    public int xp;

    public Sprite sprite;
}
