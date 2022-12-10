using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] private Animator interactionTextAnimator;
    [SerializeField] private GameObject trigger;

    private string intObj;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            intObj = "Player";
            interactionTextAnimator.SetBool("UseOpen", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        intObj = null;
        interactionTextAnimator.SetBool("UseOpen", false);
    }

    private void Update()
    {
        if (intObj == "Player")
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                Destroy(this.gameObject);
                interactionTextAnimator.SetBool("UseOpen", false);
            }
        }
    }
}
