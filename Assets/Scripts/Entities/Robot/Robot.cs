using UnityEngine;

public class Robot : Entity
{
    [SerializeField] GameObject player;
    [SerializeField] float distanceBetween;
    [SerializeField] private Animator animator;
    private float distance;
    bool isRun = false;

    private void Start()
    {
        lives = 50;
        speed = 10;
        damage = 20;
    }

    private void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        if (distance < distanceBetween)
        {
            if (direction.x > 0)
                transform.localScale = new Vector2(5, transform.localScale.y);
            else if (direction.x < 0)
                transform.localScale = new Vector2(-5, transform.localScale.y);
            isRun = true;
            animator.SetBool("run", true);
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
        else 
        {
            isRun = false;
            animator.SetBool("run", false);
        }
        if (distance < 5f)
            animator.SetBool("attack", true);
        else
            animator.SetBool("attack", false);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.Take_Damage(damage);
            Take_Damage(25);
        }
    }
}


