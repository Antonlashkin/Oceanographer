using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] GameObject mouseLookX;
    [SerializeField] GameObject mouseLookY;
    [SerializeField] GameObject UIPAnel;
    [SerializeField] Transform inventoryPanel;
    [SerializeField] GameObject posteff;
    [SerializeField] bool isOpen;
    public List<InventorySlot> slots = new List<InventorySlot>();
    private Camera _camera;


    private MouseLook lookX;
    private MouseLook lookY;
    void Start()
    {
        _camera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;


        lookX = mouseLookX.GetComponent<MouseLook>();
        lookY = mouseLookY.GetComponent<MouseLook>();

        UIPAnel.SetActive(false);
        for (int i = 0; i < inventoryPanel.childCount; i++)
        {
            if (inventoryPanel.GetChild(i).GetComponent<InventorySlot>() != null)
            {
                slots.Add(inventoryPanel.GetChild(i).GetComponent<InventorySlot>());
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && !Menu.onEnable)
        {
            isOpen = !isOpen;
            if(isOpen)
            {
                posteff.SetActive(false);
                lookX.enabled = false;
                lookY.enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                UIPAnel.SetActive(true);
            }
            else
            {
                posteff.SetActive(true);
                lookX.enabled = true;
                lookY.enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                UIPAnel.SetActive(false);
            }
        }
    }
}
