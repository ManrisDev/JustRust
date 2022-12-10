using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Panels")]
    //[SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject diePanel;

    [Header("Animators")]
    //[SerializeField] private Animator dialogueAnimator;
    [SerializeField] private Animator diePanelAnimator;

    [Header("Player")]
    [SerializeField] private GameObject player;
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

    public void RebirthOrDie()
    {
        Debug.Log("RebirthOrDie");
        diePanel.SetActive(true);
        movement.enabled = false;
    }

    public void Rebirth() {
        Debug.Log("Rebirth");
        movement.enabled = true;
        GlobalVar.Set_lives(50);
        diePanel.SetActive(false);
    }

    public void EndGame() {
        Debug.Log("EndGame");
        diePanel.SetActive(true);
        diePanelAnimator.SetTrigger("die");
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
        //pausePanel.SetActive(true);
        movement.enabled = false;
        //dialogueAnimator.SetBool("pause", true);
    }

    public void Continue()
    {
        pause = false; 
        //pausePanel.SetActive(false);
        movement.enabled = true;
        //dialogueAnimator.SetBool("pause", false);
    }
}