using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
// scriptable object item
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public string description;
}