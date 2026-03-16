using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
// scriptable object item
public class ItemData : ScriptableObject
{
    public string itemName;
    public Texture2D icon;
    public string description;
}