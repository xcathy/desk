using UnityEngine;
using UnityEngine.UIElements;

public class Note : MonoBehaviour, IObject
{
    // get the reference for the ItemData
    public ItemData note;
    public void Hover()
    {}
    public void Unhover()
    {}
    public void LeftClick()
    {
        // shows dialogue when clicked
        UI.Instance.ShowDialogue("What is this...?");
        gameObject.SetActive(false);
        Inventory.Instance.Add(note);
    }
}
