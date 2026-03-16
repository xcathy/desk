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
    private Image[] slots;
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

        // slots ref
        slots = new Image[6];

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = root.Q<Image>("slot" + (char)('0' + i));
        }
    }
    void Update()
    {
        // if ScrollWheel is activated, change the seleted item in inventory
        scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll != 0.0f)
        {
            // remove selected from the previous slot
            slots[Inventory.Instance.selected].RemoveFromClassList("selected");
            
            if (scroll > 0.0f)
            {
                // show inventory
                ShowInventory();
                // add 1 to selected
                if (Inventory.Instance.selected == 5) {
                    Inventory.Instance.selected = 0;
                } else
                {
                    Inventory.Instance.selected ++;
                }
            }

            if (scroll < 0.0f)
            {
                // show inventory
                ShowInventory();
                // delete 1 from selected
                if (Inventory.Instance.selected == 0) {
                    Inventory.Instance.selected = 5;
                } else
                {
                    Inventory.Instance.selected --;
                }
            }

            // add the selected effect on the current selected slot
            slots[Inventory.Instance.selected].AddToClassList("selected");
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