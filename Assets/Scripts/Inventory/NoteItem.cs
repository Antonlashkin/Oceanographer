using UnityEngine;


[CreateAssetMenu(fileName = "Note Item", menuName ="Inventory/Item/Note")]
public class NoteItem : ItemScriptableObject
{
    [SerializeField] int Number;

    public void Start()
    {
        itemTipe = ItemTipe.Note;
    }
}
