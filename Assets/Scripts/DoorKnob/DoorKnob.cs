using UnityEngine;

public class DoorKnob : MonoBehaviour, IObject {

    // public refs
    public Animator doorAnimator;
    // animator refs
    private Animator doorKnobAnimator;
    // private refs
    private int currSelected;
    private string itemSelected;

    public void Hover(){}
    public void Unhover(){}
    public void LeftClick()
    {
        // if animator is present
        if (doorKnobAnimator != null)
        {
            // get the name of the currently selected inventory item
            currSelected = Inventory.Instance.selected;
            if (currSelected >= 0 && currSelected < Inventory.Instance.itemList.Count)
            {
                itemSelected = Inventory.Instance.itemList[currSelected].itemName;
                Debug.Log("current selected item: " + itemSelected);

                // if key is selected, unlock
                if (itemSelected == "Key")
                {
                    doorKnobAnimator.SetTrigger("unlock");
                    doorAnimator.SetTrigger("unlock");
                    DialogueUI.Instance.ShowDialogue("I opened the door!");
                } else
                {
                    // if key is not selected, attempt to turn the doorknob, fail
                    doorKnobAnimator.SetTrigger("turn");
                    DialogueUI.Instance.ShowDialogue("The door is locked.");
                }
            } else
            {
                // if key is not selected, attempt to turn the doorknob, fail
                doorKnobAnimator.SetTrigger("turn");
                DialogueUI.Instance.ShowDialogue("The door is locked.");
            }
        }
    }

    void Start()
    {
        doorKnobAnimator = gameObject.GetComponent<Animator>();
    }
}
