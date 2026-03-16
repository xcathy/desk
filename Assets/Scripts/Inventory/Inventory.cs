using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }

    public List<ItemData> itemList = new List<ItemData>();
    // default selected item to the first one in the list which should be the empty default
    public int selected = 0;

    public void Add(ItemData item)
    {
        itemList.Add(item);
        Debug.Log("Added " + item.itemName);
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
