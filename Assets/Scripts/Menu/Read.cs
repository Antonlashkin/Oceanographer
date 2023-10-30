using System;
using UnityEngine;
using UnityEngine.UI;

public class Read : MonoBehaviour
{
    [SerializeField] GameObject slot;
    [SerializeField] GameObject text;
    [SerializeField] GameObject ender;

    public void OnRead()
    {
        if (!slot.GetComponent<InventorySlot>().isEmpty)
        {
            text.SetActive(true);
            for (int i = 1; i < 5; i++)
            {
                if (Convert.ToInt32(slot.GetComponent<InventorySlot>().item.itemName.ToString().Substring(5)) == i)
                {
                    text.transform.GetChild(0).GetComponent<Text>().text = slot.GetComponent<InventorySlot>().item.Text;
                    EndGame.dontReaded.Remove(i);
                    return;
                }
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (text.activeSelf)
            {
                text.SetActive(false);
                if (EndGame.dontReaded.Count == 0)
                {
                    ender.GetComponent<EndGame>().EndedGame();
                }
            }
        }
    }
}
