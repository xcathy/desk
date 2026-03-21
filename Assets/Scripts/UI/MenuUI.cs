using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    // Instancing
    public static MenuUI Instance { get; private set; }
    // public refs
    public UIDocument UIDoc;
    // private refs
    private VisualElement root;
    private VisualElement menu;
    private Button startoverBtn;
    private Button resumeBtn;
    private Button exitBtn;

    // Bools
    private bool startover;
    private bool resume;
    private bool exit;
    private bool enable;

    void Start()
    {
        // Instancing
        Instance = this;
        // default enable to be true
        enable = true;
        // referencing the UI elements
        root = UIDoc.rootVisualElement;
        menu = root.Q<VisualElement>("menu");

        startoverBtn = menu.Q<Button>("STARTOVER");
        resumeBtn = menu.Q<Button>("RESUME");
        exitBtn = menu.Q<Button>("EXIT");

        // default hide the menu and dialogue box
        menu.RemoveFromClassList("show");

        // adding the button event listeners
        startoverBtn.clicked += () => StartOver();
        resumeBtn.clicked += () => Resume();
        exitBtn.clicked += () => Exit();
    }

    void Update()
    {
        // if ESC is pressed, show the menu
        if (Input.GetKey(KeyCode.Escape) && enable) {
            Menu();
        }
    }
    public void Menu()
    {
        menu.AddToClassList("show");
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
        menu.RemoveFromClassList("show");
    }
    void Exit()
    {
        // force stop unity editor
        //UnityEditor.EditorApplication.isPlaying = false;
        // force stop the game
        Application.Quit();
    }
    public void SetEnable(bool status)
    {
        enable = status;
    }
}