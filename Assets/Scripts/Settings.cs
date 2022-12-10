using UnityEngine;

public class Settings : MonoBehaviour
{
   [SerializeField] private GameObject settingsPanel;
   [SerializeField] private GameObject menuPanel;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SettingsOff();
        }
    }

    /*public void SettingsOn()
    {
        settingsPanel.SetActive(true);
        FindObjectOfType<Menu>().BackToMenu();
    }*/

    public void SettingsOff()
    {
        menuPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }
}
