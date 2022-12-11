using UnityEngine;

public class PickUpSword : MonoBehaviour
{
    [SerializeField] GameObject katana;
    [SerializeField] GameObject katanaPlayer;
    [SerializeField] Animator interactionAnimator;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
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
            FindObjectOfType<Player>().PickUpSword();
            interactionAnimator.SetBool("UseOpen", false);
        }
    }
}
