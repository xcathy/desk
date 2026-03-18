using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;

public class DialogueUI : MonoBehaviour
{
    // Instancing
    public static DialogueUI Instance { get; private set; }
    
    // public refs
    public UIDocument UIDoc;
    // private refs
    private VisualElement root;
    private VisualElement dialogue;
    private Label text;

    void Start()
    {
        // Instancing
        Instance = this;

        root = UIDoc.rootVisualElement;
        dialogue = root.Q<VisualElement>("dialogue");
        text = root.Q<Label>("text");

        // default hide the dialogue box
        dialogue.RemoveFromClassList("show");
    }

    void Update()
    {
        // if SPACE is pressed, hide the dialogue
        if (Input.GetKey(KeyCode.Space)) {
            HideDialogue();
        }
    }

    // Dialogue display
    public void ShowDialogue(string textContent, float delay = 0.05f)
    {
        dialogue.AddToClassList("show");
        // stop previous typing
        StopAllCoroutines();
        // start new typing
        StartCoroutine(Typing(textContent, delay));
    }

    public void HideDialogue()
    {
        dialogue.RemoveFromClassList("show");
    }

    // text typing method
    private IEnumerator Typing(string dialogue, float delay)
    {
        text.text = "";

        foreach (char c in dialogue)
        {
            text.text += c;
            yield return new WaitForSeconds(delay);
        }
    }

}
