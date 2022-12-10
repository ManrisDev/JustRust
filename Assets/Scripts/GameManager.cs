using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject diePanel;

    [Header("Animators")]
    [SerializeField] private Animator dialogueAnimator;

    [Header("Player")]
    [SerializeField] private Player movement;

    private bool pause = false;

    public void Start()
    {
        GlobalVar.Set_level_index(SceneManager.GetActiveScene().buildIndex);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pause)
        {
            Pause();
        }
    }

    public void Rebirth() {

    }

    public void Restart()
    {
        GlobalVar.Set_level_index(SceneManager.GetActiveScene().buildIndex - 1);
        //SceneManager.LoadScene("Loading");
    }

    public void MainMenu()
    {
        //Level_1 build index
        GlobalVar.Set_level_index(0);
        SceneManager.LoadScene("Menu");
    }

    public void NextScene()
    {
        SceneManager.LoadScene("Loading");
    }

    public void EndGame()
    {
        diePanel.SetActive(true);
        GlobalVar.Set_level_index(0);
        FindObjectOfType<Player>().Die();
    }

    public void LoadLastCutScene()
    {
        SceneManager.LoadScene("LastCutScene");
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Pause()
    {
        pause = true; 
        pausePanel.SetActive(true);
        movement.enabled = false;
        dialogueAnimator.SetBool("pause", true);
    }

    public void Continue()
    {
        pause = false; 
        pausePanel.SetActive(false);
        movement.enabled = true;
        dialogueAnimator.SetBool("pause", false);
    }
}