using UnityEngine;
using UnityEngine.UIElements;

public class PreviewUI : MonoBehaviour
{
    public static PreviewUI Instance { get; private set; }
    // public refs
    public UIDocument UIDoc;
    public RenderTexture previewRT;

    // private refs
    private VisualElement root;
    private VisualElement previewMode;
    private VisualElement preview;
    private Label title;
    private Label desc;
    // private bools
    private bool previewModeOn = false;

    void Start()
    {
        // Instancing
        Instance = this;
        // referencing the UI elements
        root = UIDoc.rootVisualElement;
        previewMode = root.Q<VisualElement>("previewMode");
        preview = root.Q<VisualElement>("preview");
        title = root.Q<Label>("itemName");
        desc = root.Q<Label>("itemDesc");
        preview.style.backgroundImage = new StyleBackground(Background.FromRenderTexture(previewRT));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            previewModeOn = !previewModeOn;
        }

        if (previewModeOn) 
        { 
            ShowPreview();
        } else
        {
            HidePreview();
        }
    }
    void ShowPreview()
    {
        previewMode.AddToClassList("show");
    }
    void HidePreview()
    {
        previewMode.RemoveFromClassList("show");
    }

    public void SetTitle(string titleText)
    {
        title.text = titleText;
    }

    public void SetDesc(string descText)
    {
        desc.text = descText;
    }
}