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
    // items
    private VisualElement items;
    private float scroll;

    // timer
    private float inventoryTimer = 0f;
    private float inventoryTimeLimit = 20.0f;

    void Start()
    {
        // Instancing
        Instance = this;

        // referencing the UI elements
        root = GetComponent<UIDocument>().rootVisualElement;
        // dialogue box
        dialogue = root.Q<VisualElement>("dialogue");
        text = root.Q<Label>("text");
        // item box
        items = root.Q<VisualElement>("items");

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
        // if ScrollWheel is activated, change the seleted item in inventory
        scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll != 0.0f)
        {
            if (scroll > 0.0f)
            {
                ShowInventory();
                Debug.Log("scroll up");
            }

            if (scroll < 0.0f)
            {
                ShowInventory();
                Debug.Log("scroll down");
            }
        }
        
        // if nothing happens for a long time, hide inventory
        inventoryTimer += 0.01f;
        if (inventoryTimer > inventoryTimeLimit)
        {
            HideInventory();
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

    // Inventory display
    public void ShowInventory()
    {
        items.AddToClassList("show");
        // set show inventory timer to 0
        inventoryTimer = 0f;

    }
    public void HideInventory()
    {
        items.RemoveFromClassList("show");
    }

}
