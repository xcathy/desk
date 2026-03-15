using UnityEngine;
using UnityEngine.UIElements;

public class Note : MonoBehaviour, IObject
{
    // UI refs
    public UIDocument UIDoc;
    // private vars
    private VisualElement root;
    private VisualElement dialogue;
    private Label text;
    
    public void Hover()
    {}
    public void Unhover()
    {}
    public void LeftClick()
    {
        // shows dialogue when clicked
        dialogue.style.display = DisplayStyle.Flex;
        text.text = "What is this...?";
    }

    void Start()
    {
        root = UIDoc.rootVisualElement;
        dialogue = root.Q<VisualElement>("dialogue");
        text = root.Q<Label>("text");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && dialogue.style.display == DisplayStyle.Flex)
        {
            dialogue.style.display = DisplayStyle.None;
        }
    }
}
