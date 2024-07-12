using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCntrl : MonoBehaviour
{
    [SerializeField] private GameObject inventoryCollection;
    [SerializeField] private GameObject inventoryItemPrefab;

    [SerializeField] private InventoryItemSO[] itemsList;

    // Start is called before the first frame update
    void Start()
    {
        foreach(InventoryItemSO item in itemsList)
        {
            GameObject go = Instantiate(inventoryItemPrefab, inventoryCollection.transform);
            go.GetComponent<InventoryItemCntrl>().SetItem(item);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
