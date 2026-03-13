using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;

public class UI : MonoBehaviour
{
    // Input vars
    private Keyboard keyboard;
    // Reference vars
    private VisualElement root;
    private VisualElement menu;
    private Button startover;
    private Button resume;
    private Button exit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // referencing the inputs
        keyboard =  Keyboard.current;

        // referencing the UI elements
        root = GetComponent<UIDocument>().rootVisualElement;
        menu = root.Q<VisualElement>("menu");

        startover = menu.Q<Button>("STARTOVER");
        resume = menu.Q<Button>("RESUME");
        exit = menu.Q<Button>("EXIT");

        // default hide the menu
        menu.style.display = DisplayStyle.None;
    }

    // Update is called once per frame
    void Update()
    {
        // if ESC is pressed, show the menu
        if (keyboard != null)
        {
            if (keyboard.escapeKey.isPressed) menu.style.display = DisplayStyle.Flex;
        }
        // if exit button clicked, quit game
        exit.clicked += () =>
        {
            // force stop unity editor
            UnityEditor.EditorApplication.isPlaying = false;
            // force stop the game
            Application.Quit();
        };
    }
}
