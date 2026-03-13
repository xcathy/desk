using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    // Input vars
    private Keyboard keyboard;
    private Mouse mouse;
    // Reference vars
    private VisualElement root;
    private VisualElement menu;
    private Button startoverBtn;
    private Button resumeBtn;
    private Button exitBtn;

    // Bools
    private bool startover;
    private bool resume;
    private bool exit;

    void Start()
    {
        // referencing the inputs
        keyboard =  Keyboard.current;
        mouse = Mouse.current;

        // referencing the UI elements
        root = GetComponent<UIDocument>().rootVisualElement;
        menu = root.Q<VisualElement>("menu");

        startoverBtn = menu.Q<Button>("STARTOVER");
        resumeBtn = menu.Q<Button>("RESUME");
        exitBtn = menu.Q<Button>("EXIT");

        // default hide the menu
        menu.style.display = DisplayStyle.None;

        // adding the button event listeners
        startoverBtn.clicked += () => StartOver();
        resumeBtn.clicked += () => Resume();
        exitBtn.clicked += () => Exit();
    }

    // Update is called once per frame
    void Update()
    {
        // if ESC is pressed, show the menu
        if (keyboard != null)
        {
            if (keyboard.escapeKey.isPressed) menu.style.display = DisplayStyle.Flex;
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
