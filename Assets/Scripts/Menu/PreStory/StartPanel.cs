using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPanel : MonoBehaviour
{
    public GameObject panel;
    public GameObject button;
    public void StartingPanel()
    {
        panel.SetActive(true);
        button.SetActive(true);
    }
}
