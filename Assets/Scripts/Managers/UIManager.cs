using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("UI Panels")]
    [SerializeField] private GameObject currentPanel;

    public void SwitchPanel(GameObject newPanel)
    {
        if(currentPanel != null)
        {
            currentPanel.SetActive(false);
        }
        newPanel.SetActive(true);
        currentPanel = newPanel;
    }
    public void LoadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
    public void SetPause(bool isPaused)
    {
        Time.timeScale = isPaused ? 0 : 1;
    }
    public void ResetAllData()
    {
        JsonSave.Instance.DeleteGame();
        PlayerPrefs.DeleteAll();
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
    public void QuitGame() => Application.Quit();
}
