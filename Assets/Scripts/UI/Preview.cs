using UnityEngine;
using UnityEngine.UIElements;

public class Preview : MonoBehaviour
{
    public static Preview Instance { get; private set; }
    // public refs
    public UIDocument UIDoc;
    public RenderTexture previewRT;

    // private refs
    private VisualElement root;
    private VisualElement previewBG;
    private VisualElement preview;
    private Label title;
    private Label desc;
    // private bools
    private bool previewMode = false;

    void Start()
    {
        // Instancing
        Instance = this;
        // referencing the UI elements
        root = UIDoc.rootVisualElement;
        previewBG = root.Q<VisualElement>("previewBG");
        preview = root.Q<VisualElement>("preview");
        title = root.Q<Label>("itemName");
        desc = root.Q<Label>("itemDesc");
        preview.style.backgroundImage = new StyleBackground(Background.FromRenderTexture(previewRT));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            previewMode = !previewMode;
        }

        if (previewMode) 
        { 
            ShowPreview();
        } else
        {
            HidePreview();
        }
    }
    void ShowPreview()
    {
        previewBG.AddToClassList("show");
        preview.AddToClassList("show");
        title.AddToClassList("show");
        desc.AddToClassList("show");
    }
    void HidePreview()
    {
        previewBG.RemoveFromClassList("show");
        preview.RemoveFromClassList("show");
        title.RemoveFromClassList("show");
        desc.RemoveFromClassList("show");
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