using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public static void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Defense1");
    }
    public static void UpgradeMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("UpgradeMenu");
    }
    public static void QuitGame()
    {
        Application.Quit();
    }
}
