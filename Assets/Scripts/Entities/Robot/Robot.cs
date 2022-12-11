using UnityEngine;

public class Robot : Entity
{
    [SerializeField] GameObject player;
    [SerializeField] float distanceBetween;
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
            isRun = true;
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
        
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


