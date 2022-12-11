using UnityEngine;

public class PickUpSword : MonoBehaviour
{
    [SerializeField] GameObject katana;
    [SerializeField] GameObject katanaPlayer;
    [SerializeField] Animator interactionAnimator;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            interactionAnimator.SetBool("UseOpen", true);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            katana.SetActive(false);
            katanaPlayer.SetActive(true);
            interactionAnimator.SetBool("UseOpen", false);
        }
    }
}
