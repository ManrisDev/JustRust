using UnityEngine;

public class FallingRobot : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D (Collision2D collision) {
        if (collision.gameObject.tag == "Ground") {
            animator.SetTrigger("crash");
            audioSource.PlayOneShot(audioSource.clip);
        }
    }
}
