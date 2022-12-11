using UnityEngine;

public class rabat : MonoBehaviour
{
    [SerializeField] private GameObject robot;
    [SerializeField] private Animator animator;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            robot.SetActive(true);
            animator.SetTrigger("aboba");
        }
    }
}
