using UnityEngine;
using UnityEngine.UIElements;

public class MagnifyUI : MonoBehaviour
{
    // public refs
    public UIDocument UIDoc;
    // private refs
    private VisualElement root;
    private VisualElement magnify;
    // private bools
    private bool magnifyOpen = false;

    void Start()
    {
        // referencing the UI elements
        root = UIDoc.rootVisualElement;
        magnify = root.Q<VisualElement>("magnify");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            magnifyOpen = !magnifyOpen;
        }

        if (magnifyOpen) 
        { 
            ShowMagnify();
        } else
        {
            HideMagnify();
        }
    }
    void ShowMagnify()
    {
        magnify.AddToClassList("show");
    }
    void HideMagnify()
    {
        magnify.RemoveFromClassList("show");
    }
}