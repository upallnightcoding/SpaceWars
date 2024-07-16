using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName = "InventoryItem", menuName = "Space Wars/Inventory Item")]
public class InventoryItemSO : ScriptableObject
{
    public InventoryItemType itemType;

    public string itemName;

    [TextArea(4, 4)]
    public string description;

    public int xp;

    public Sprite sprite;

    [Header("Gun Shooting Attributes")]
    public int ammoCount;
    public float reloadTime;
}

public enum InventoryItemType
{
    AMMO,
    BOMB,
    SHIELD,
    MISSILE
}
