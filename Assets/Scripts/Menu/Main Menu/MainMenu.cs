using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] GameObject controller;
    [SerializeField] GameObject mainMenu;

    public void OnController()
    {
        controller.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void OnExit()
    {
        Application.Quit();
    }
}
