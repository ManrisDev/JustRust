using UnityEngine;

public class PromtTrigger : MonoBehaviour
{
    [SerializeField] GameObject promts;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            promts.SetActive(true);
        }
    }
}
