using UnityEngine;

public class Controller : MonoBehaviour
{

    [SerializeField] GameObject controller;
    [SerializeField] GameObject mainMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            controller.SetActive(false);
            mainMenu.SetActive(true);
        }
    }
}
