using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void ChangeScenes(int scene)
    {
        SceneManager.LoadScene(scene);
        //Debug.Log("Start");
    }
}
