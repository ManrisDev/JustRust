using UnityEngine;

public class Spider : Entity
{
    public GameObject player;
    public float distanceBetween;
    public bool isRun = false;
    public AudioSource audioSource;
    private float distance;

    private void Start()
    {
        lives = 10;
        speed = 5;
        damage = 5;
    }

    private void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        if (distance < distanceBetween)
        {
            isRun = true;
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
        else
        {
            audioSource.Stop();
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


