using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameWinUI : MonoBehaviour
{
    // Instancing
    public static GameWinUI Instance { get; private set; }
    
    // public refs
    public UIDocument UIDoc;
    // private refs
    private VisualElement root;
    private VisualElement gameWinMenu;
    private Button againBtn;
    private Button quitBtn;
    // Bools
    private bool again;
    private bool quit;

     void Start()
    {
        // Instancing
        Instance = this;

        root = UIDoc.rootVisualElement;
        gameWinMenu = root.Q<VisualElement>("gamewin");

        againBtn = gameWinMenu.Q<Button>("AGAIN");
        quitBtn = gameWinMenu.Q<Button>("QUIT");

        // default hide the game win menu
        gameWinMenu.RemoveFromClassList("show");

        // adding the button event listeners
        againBtn.clicked += () => Again();
        quitBtn.clicked += () => Quit();
    }

    // display game win menu
    public void GameWin()
    {
        gameWinMenu.AddToClassList("show");
        // show the mouse
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        UnityEngine.Cursor.visible = true;
    }

    void Again()
    {
        // reload the main scene
        SceneManager.LoadScene("Main");
    }
    void Quit()
    {
        // force stop unity editor
        UnityEditor.EditorApplication.isPlaying = false;
        // force stop the game
        Application.Quit();
    }
}