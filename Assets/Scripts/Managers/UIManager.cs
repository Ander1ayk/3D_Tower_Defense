using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("UI Panels")]
    [SerializeField] private GameObject currentPanel;
    [SerializeField] private AudioClip buttonClickSFX;

    public void SwitchPanel(GameObject newPanel)
    {
        AudioManager.Instance.PlaySFX(buttonClickSFX, false, 0.9f);
        if (currentPanel != null)
        {
            currentPanel.SetActive(false);
        }
        newPanel.SetActive(true);
        currentPanel = newPanel;
    }
    public void LoadScene(string sceneName)
    {
        AudioManager.Instance.PlaySFX(buttonClickSFX, false, 0.9f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
    public void SetPause(bool isPaused)
    {
        AudioManager.Instance.PlaySFX(buttonClickSFX, false, 0.9f);
        Time.timeScale = isPaused ? 0 : 1;
    }
    public void ResetAllData()
    {
        AudioManager.Instance.PlaySFX(buttonClickSFX, false, 0.9f);
        JsonSave.Instance.DeleteGame();
        PlayerPrefs.DeleteAll();
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
    public void QuitGame() => Application.Quit();
}
