using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;

public class InventoryUI : MonoBehaviour
{
    // Instancing
    public static InventoryUI Instance { get; private set; }
    // public refs
    public UIDocument UIDoc;
    // private refs
    private VisualElement root;
    private VisualElement items;
    private float scroll;

    // timer
    private float inventoryTimer = 0f;
    private float inventoryTimeLimit = 20.0f;

    void Start()
    {
        // Instancing
        Instance = this;

        // referencing the UI elements
        root = UIDoc.rootVisualElement;
        items = root.Q<VisualElement>("items");
    }
    void Update()
    {
        // if ScrollWheel is activated, change the seleted item in inventory
        scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll != 0.0f)
        {
            if (scroll > 0.0f)
            {
                ShowInventory();
                Debug.Log("scroll up");
            }

            if (scroll < 0.0f)
            {
                ShowInventory();
                Debug.Log("scroll down");
            }
        }
        
        // if nothing happens for a long time, hide inventory
        inventoryTimer += 0.01f;
        if (inventoryTimer > inventoryTimeLimit)
        {
            HideInventory();
        }
    }
    // Inventory display
    public void ShowInventory()
    {
        items.AddToClassList("show");
        // set show inventory timer to 0
        inventoryTimer = 0f;

    }
    public void HideInventory()
    {
        items.RemoveFromClassList("show");
    }
}