using UnityEngine;

public class Key : MonoBehaviour, IObject
{
    // ItemData refs
    public ItemData item;
    public Animator safeDoorAnimator;

    public void Hover(){}
    public void Unhover(){}
    public void LeftClick()
    {
        // close safe door when clicked
        gameObject.SetActive(false);
        Inventory.Instance.Add(item);
        InventoryUI.Instance.ShowInventory();
        safeDoorAnimator.SetBool("unlock", false);
    }
}