using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadGame()
    {
        LoadScene("SampleScene");
    }

    public void LoadMenu()
    {
        LoadScene("Menu");
    }
}