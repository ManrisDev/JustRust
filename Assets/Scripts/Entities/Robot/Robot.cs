using UnityEngine;

public class Robot : Entity
{
    [SerializeField] GameObject player;
    [SerializeField] float distanceBetween;
    [SerializeField] private Animator animator;
    public bool firstRobot;
    private float distance;

    private void Start()
    {
        lives = 100;
        speed = 2;
        damage = 20;
    }

    private void Update()
    {
        if(!firstRobot)
            Run();
    }

    public void Run()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        if (distance < distanceBetween)
        {
            if (direction.x > 0)
                transform.localScale = new Vector2(5, transform.localScale.y);
            else if (direction.x < 0)
                transform.localScale = new Vector2(-5, transform.localScale.y);
            animator.SetBool("run", true);
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position + new Vector3(3f, 0, 0), speed * Time.deltaTime);
        }
        else 
        {
            animator.SetBool("run", false);
        }
        if (distance < 5f)
            animator.SetBool("attack", true);
        else
            animator.SetBool("attack", false);
    }

    public void MoveToPoint()
    {
        animator.SetBool("run", true);
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position + new Vector3(10f, 0, 0), speed * Time.deltaTime);
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


