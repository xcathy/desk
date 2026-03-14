using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    // Reference vars
    private VisualElement root;
    // menu
    private VisualElement menu;
    private Button startoverBtn;
    private Button resumeBtn;
    private Button exitBtn;
    // dialogue
    private VisualElement dialogue;
    // items
    private VisualElement items;

    // Bools
    private bool startover;
    private bool resume;
    private bool exit;

    void Start()
    {
        // referencing the UI elements
        root = GetComponent<UIDocument>().rootVisualElement;
        menu = root.Q<VisualElement>("menu");

        startoverBtn = menu.Q<Button>("STARTOVER");
        resumeBtn = menu.Q<Button>("RESUME");
        exitBtn = menu.Q<Button>("EXIT");
        // dialogue box
        dialogue = root.Q<VisualElement>("dialogue");
        // item box
        items = root.Q<VisualElement>("items");

        // default hide the menu and dialogue box
        menu.style.display = DisplayStyle.None;
        dialogue.style.display = DisplayStyle.None;
        // default partially hide the items
        items.style.top = Length.Percent(-15);

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
            menu.style.display = DisplayStyle.Flex;
            // show the mouse
            UnityEngine.Cursor.lockState = CursorLockMode.None;
            UnityEngine.Cursor.visible = true;
        }
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
}
