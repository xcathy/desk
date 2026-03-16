using UnityEngine;
using UnityEngine.UIElements;

public class Preview : MonoBehaviour
{
    // public refs
    public UIDocument UIDoc;
    public RenderTexture previewRT;

    // private refs
    private VisualElement root;
    private VisualElement previewBG;
    private VisualElement preview;
    // private bools
    private bool previewMode = false;

    void Start()
    {
        // referencing the UI elements
        root = UIDoc.rootVisualElement;
        previewBG = root.Q<VisualElement>("previewBG");
        preview = root.Q<VisualElement>("preview");
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
    }
    void HidePreview()
    {
        previewBG.RemoveFromClassList("show");
        preview.RemoveFromClassList("show");
    }
}