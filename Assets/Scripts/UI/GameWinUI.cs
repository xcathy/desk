using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;

public class GameWinUI : MonoBehaviour
{
    // Instancing
    public static GameWinUI Instance { get; private set; }
    
    // public refs
    public UIDocument UIDoc;
    // private refs
    private VisualElement root;
    private VisualElement gameWinMenu;

     void Start()
    {
        // Instancing
        Instance = this;

        root = UIDoc.rootVisualElement;
        gameWinMenu = root.Q<VisualElement>("gamewin");

        // default hide the game win menu
        gameWinMenu.RemoveFromClassList("show");
    }

    // display game win menu
    public void GameWin()
    {
        gameWinMenu.AddToClassList("show");
    }
}