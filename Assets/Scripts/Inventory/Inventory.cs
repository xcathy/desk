using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }
    public List<ItemData> items = new List<ItemData>();

    public void Add(ItemData item)
    {
        items.Add(item);
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
