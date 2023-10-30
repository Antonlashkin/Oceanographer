using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    [SerializeField] GameObject mouseLookX;
    [SerializeField] GameObject mouseLookY;
    [SerializeField] GameObject inventory;
    [SerializeField] GameObject endGameMenu;
    [SerializeField] GameObject posteff;

    private MouseLook lookX;
    private MouseLook lookY;

    public static List<int> dontReaded = new List<int>() { 1, 2, 3, 4 };

    private void Start()
    {
        lookX = mouseLookX.GetComponent<MouseLook>();
        lookY = mouseLookY.GetComponent<MouseLook>();
    }

    public void EndedGame()
    {

       //GameObject[] enemy = GameObject.FindGameObjectsWithTag("Note");
       Time.timeScale = 0f;
       lookX.enabled = false;
       lookY.enabled = false;
       Cursor.lockState = CursorLockMode.None;
       Cursor.visible = true;
       endGameMenu.transform.GetChild(1).GetComponent<Text>().text = "Game Over";
       Menu menu = inventory.GetComponent<Menu>();
       menu.enabled = false;
       posteff.SetActive(false);
        endGameMenu.SetActive(true);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
