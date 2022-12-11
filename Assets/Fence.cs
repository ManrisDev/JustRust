using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : MonoBehaviour
{
    [SerializeField] private Animator interactionTextAnimator;
    [SerializeField] private GameObject trigger;
    [SerializeField] private GameObject fence;

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
                fence.SetActive(false);
                interactionTextAnimator.SetBool("UseOpen", false);
            }
        }
    }
}
