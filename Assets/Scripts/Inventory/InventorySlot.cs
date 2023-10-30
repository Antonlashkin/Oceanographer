using UnityEngine.UI;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    public bool isEmpty = true;
    public ItemScriptableObject item;
    public GameObject iconGameObject;

    private void Start()
    {
        iconGameObject = transform.GetChild(0).gameObject;
    }
    public void SetIcon(Sprite icon)
    {
        iconGameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        iconGameObject.GetComponent<Image>().sprite = icon;
    }
}

