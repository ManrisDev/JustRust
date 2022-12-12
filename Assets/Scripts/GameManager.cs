using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject diePanel;
    [SerializeField] private GameObject rebornPanel;

    [SerializeField] private Player movement;

    public void Restart()
    {
        GlobalVar.Set_level_index(SceneManager.GetActiveScene().buildIndex - 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RebirthOrDie()
    {
        rebornPanel.SetActive(true);
        movement.enabled = false;
    }

    public void Rebirth() {
        movement.enabled = true;
        GlobalVar.Set_lives(200);
        rebornPanel.SetActive(false);
    }

    public void EndGame() {
        rebornPanel.SetActive(false);
        diePanel.SetActive(true);
        FindObjectOfType<Player>().Die();
    }
}