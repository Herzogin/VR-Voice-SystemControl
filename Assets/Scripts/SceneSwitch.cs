using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    string currentSceneName;

    public void switchToScene(string sceneName)
    {
        currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName != sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
        if (currentSceneName == sceneName)
        {
            Debug.Log("already your current scene");
        }
    }
}
