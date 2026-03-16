using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }

    public List<ItemData> itemList = new List<ItemData>();
    // default selected item to the first one in the list which should be the empty default
    public int selected = 0;
    // get the list of preview items
    public Transform previewObj;

    public void Add(ItemData item)
    {
        itemList.Add(item);
        Debug.Log("Added " + item.itemName);
    
        // remove the currently selected
        InventoryUI.Instance.UnHightlightSlot(selected);
        // set selected to be the current position of the added item
        selected = itemList.Count - 1;
        Debug.Log("itemList count: " + itemList.Count);

        // set the image of the slot to be the item image
        InventoryUI.Instance.ChangeImg(selected, item.icon);
        InventoryUI.Instance.HightlightSlot(selected);

        // set the preview object in the list to be active
        foreach (Transform childObj in previewObj)
        {
            GameObject child = childObj.gameObject;

            Debug.Log(child.name);
            if (child.name == item.itemName) {
                child.SetActive(true);
            } else
            {
                child.SetActive(false);
            }
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
