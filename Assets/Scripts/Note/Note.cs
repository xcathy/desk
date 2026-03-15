using UnityEngine;
using UnityEngine.UIElements;

public class Note : MonoBehaviour, IObject
{
    public void Hover()
    {}
    public void Unhover()
    {}
    public void LeftClick()
    {
        // shows dialogue when clicked
        UI.Instance.ShowDialogue("What is this...?");
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            UI.Instance.HideDialogue();
        }
    }
}
