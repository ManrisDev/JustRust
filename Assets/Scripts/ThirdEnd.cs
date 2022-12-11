using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThirdEnd : MonoBehaviour
{
    [SerializeField] private Animator interactionTextAnimatorThird;
    [SerializeField] private GameObject trigger;

    private string intObjThird;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            intObjThird = "Player";
            interactionTextAnimatorThird.SetBool("UseOpen", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        intObjThird = null;
        interactionTextAnimatorThird.SetBool("UseOpen", false);
    }

    private void Update()
    {
        if (intObjThird == "Player")
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                Destroy(this.gameObject);
                interactionTextAnimatorThird.SetBool("UseOpen", false);
                SceneManager.LoadScene("ThirdEnd");
            }
        }
    }
}
