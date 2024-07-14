using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCntrl : MonoBehaviour
{
    [SerializeField] private GameObject inventoryCollection;
    [SerializeField] private GameObject weaponsCollection;

    [SerializeField] private GameObject inventoryItemPrefab;

    [SerializeField] private InventoryItemSO[] itemsList;

    private Dictionary<string, GameObject> itemMapping = 
        new Dictionary<string, GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        foreach(InventoryItemSO item in itemsList)
        {
            GameObject go = Instantiate(inventoryItemPrefab, inventoryCollection.transform);
            go.GetComponent<InventoryItemCntrl>().SetItem(
                item, inventoryCollection, weaponsCollection
            );

            itemMapping.Add(item.itemName, go);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectionHasBeenMade(InventoryItemSO inventoryItem)
    {
        Debug.Log($"Inventory Selection: {inventoryItem.itemName}");

        if (itemMapping.TryGetValue(inventoryItem.itemName, out GameObject go))
        {
            go.GetComponent<InventoryItemCntrl>().SwitchInventory();
        }
    }

    private void OnEnable()
    {
        EventManager.Instance.OnInventorySelection += SelectionHasBeenMade;
    }

    private void OnDisable()
    {
        EventManager.Instance.OnInventorySelection -= SelectionHasBeenMade;
    }
}
