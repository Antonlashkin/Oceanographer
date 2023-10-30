using UnityEngine;

public enum ItemTipe 
{   
    Note,
    HealItem,
    Weapon
}

public class ItemScriptableObject : ScriptableObject
{
    public Sprite icon;
    public string Text;
    public GameObject itemPrefab;
    public string itemName;
    public ItemTipe itemTipe;
}
