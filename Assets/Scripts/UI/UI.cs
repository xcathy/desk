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
    // menu
    private VisualElement menu;
    private Button startoverBtn;
    private Button resumeBtn;
    private Button exitBtn;
    // dialogue
    private VisualElement dialogue;
    private Label text;
    // items
    private VisualElement items;

    // Bools
    private bool startover;
    private bool resume;
    private bool exit;

    void Start()
    {
        // Instancing
        Instance = this;

        // referencing the UI elements
        root = GetComponent<UIDocument>().rootVisualElement;
        menu = root.Q<VisualElement>("menu");

        startoverBtn = menu.Q<Button>("STARTOVER");
        resumeBtn = menu.Q<Button>("RESUME");
        exitBtn = menu.Q<Button>("EXIT");
        // dialogue box
        dialogue = root.Q<VisualElement>("dialogue");
        text = root.Q<Label>("text");
        // item box
        items = root.Q<VisualElement>("items");

        // default hide the menu and dialogue box
        menu.style.display = DisplayStyle.None;
        dialogue.style.display = DisplayStyle.None;

        // adding the button event listeners
        startoverBtn.clicked += () => StartOver();
        resumeBtn.clicked += () => Resume();
        exitBtn.clicked += () => Exit();
    }

    // Update is called once per frame
    void Update()
    {
        // if ESC is pressed, show the menu
        if (Input.GetKey(KeyCode.Escape)) {
            Menu();
        }
        // if SPACE is pressed, hide the dialogue
        if (Input.GetKey(KeyCode.Space)) {
            HideDialogue();
        }
    }

    // Menu
    public void Menu()
    {
        menu.style.display = DisplayStyle.Flex;
        // show the mouse
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        UnityEngine.Cursor.visible = true;
    }

    void StartOver()
    {
        // reload the main scene
        SceneManager.LoadScene("Main");
    }
    void Resume()
    {
        // hide the mouse
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
        // hide the menu
        menu.style.display = DisplayStyle.None;
    }
    void Exit()
    {
        // force stop unity editor
        UnityEditor.EditorApplication.isPlaying = false;
        // force stop the game
        Application.Quit();
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

    // Inventory display
    public void showInventory()
    {
        items.AddToClassList("show");
    }
    public void hideInventory()
    {
        items.RemoveFromClassList("show");
    }

}
