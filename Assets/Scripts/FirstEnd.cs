using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstEnd : MonoBehaviour
{
    [SerializeField] private Animator interactionTextAnimatorFirst;
    [SerializeField] private GameObject trigger;
    public bool isAlive = true;



    private string intObjFirst;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            intObjFirst = "Player";
            interactionTextAnimatorFirst.SetBool("UseOpen", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        intObjFirst = null;
        interactionTextAnimatorFirst.SetBool("UseOpen", false);
    }

    private void Update()
    {
        if (intObjFirst == "Player")
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                Destroy(this.gameObject);
                interactionTextAnimatorFirst.SetBool("UseOpen", false);
                SceneManager.LoadScene("FirstEnd");
            }
        }

    }
}

