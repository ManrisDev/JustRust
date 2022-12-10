using UnityEngine;

public class DiePanel : MonoBehaviour
{
    private float start_time;
    private float end_time;

    private void Start() 
    {
        Debug.Log("Start");
        start_time = Time.time;
        end_time = start_time + 5f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) 
            FindObjectOfType<GameManager>().Rebirth();
        if (Time.time > end_time)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    private void End() {
        Debug.Log("End");
        FindObjectOfType<GameManager>().EndGame();
    }
}
