using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject menuPanel;
    [SerializeField] GameObject settingsPanel;
    public void StartGame()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void Settings()
    {
        menuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
