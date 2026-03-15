using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System.Collections;

public class UI : MonoBehaviour
{
    // UI Instancing
    public static UI Instance { get; private set; }

    // Reference vars
    private VisualElement root;
    // dialogue
    private VisualElement dialogue;
    private Label text;

    void Start()
    {
        // Instancing
        Instance = this;

        // referencing the UI elements
        root = GetComponent<UIDocument>().rootVisualElement;
        // dialogue box
        dialogue = root.Q<VisualElement>("dialogue");
        text = root.Q<Label>("text");

        // default hide the dialogue box
        dialogue.style.display = DisplayStyle.None;
    }

    // Update is called once per frame
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
        dialogue.style.display = DisplayStyle.Flex;
        // stop previous typing
        StopAllCoroutines();
        // start new typing
        StartCoroutine(Typing(textContent, delay));
    }

    public void HideDialogue()
    {
        dialogue.style.display = DisplayStyle.None;
    }

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
