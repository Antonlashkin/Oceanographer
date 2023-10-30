using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject mouseLookX;
    [SerializeField] GameObject mouseLookY;
    [SerializeField] GameObject inventory;
    [SerializeField] GameObject posteff;
    public static bool onEnable = false;

    private MouseLook lookX;
    private MouseLook lookY;

    public void Start()
    {
        transform.GetChild(2).gameObject.SetActive(false);
        lookX = mouseLookX.GetComponent<MouseLook>();
        lookY = mouseLookY.GetComponent<MouseLook>();
    }


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!onEnable)
            {
                posteff.SetActive(false);
                Time.timeScale = 0f;
                lookX.enabled = false;
                lookY.enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                transform.GetChild(2).gameObject.SetActive(true);
                onEnable = true;
            }
            else
            {
                if (!inventory.activeSelf)
                {
                    lookX.enabled = true;
                    lookY.enabled = true;
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                }
                posteff.SetActive(true);
                Time.timeScale = 1f;
                transform.GetChild(2).gameObject.SetActive(false);
                onEnable = false;
            }
        }
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
