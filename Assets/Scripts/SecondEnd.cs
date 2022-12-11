using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondEnd : MonoBehaviour
{
    [SerializeField] private Animator interactionTextAnimatorSecond;
    [SerializeField] private GameObject trigger;

    private string intObjSecond;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            intObjSecond = "Player";
            interactionTextAnimatorSecond.SetBool("UseOpen", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        intObjSecond = null;
        interactionTextAnimatorSecond.SetBool("UseOpen", false);
    }

    private void Update()
    {
        if (intObjSecond == "Player")
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                Destroy(this.gameObject);
                interactionTextAnimatorSecond.SetBool("UseOpen", false);
                SceneManager.LoadScene("SecondEnd");
            }
        }
    }
}
