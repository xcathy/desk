using UnityEngine;

public class Plushie : MonoBehaviour, IObject
{
    // UI canvas refs
    public GameObject hintCanvas;
    // ItemData refs
    public ItemData plushie;
    // bools
    public void Hover()
    {
        if (hintCanvas!= null) {
            hintCanvas.SetActive(true);
        }
    }
    public void Unhover()
    {
        if (hintCanvas!= null) {
            hintCanvas.SetActive(false);
        }
    }
    public void LeftClick()
    {
        // shows dialogue when clicked
        gameObject.SetActive(false);
        Inventory.Instance.Add(plushie);
        InventoryUI.Instance.ShowInventory();
    }

}


