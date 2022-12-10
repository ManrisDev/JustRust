using UnityEngine;

public class Boss : Entity
{
    [SerializeField] private float speed = 2.5f;

    [SerializeField] private Transform player;
    private Animator animator;
    private Rigidbody2D rigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        animator.SetTrigger("dialogueIsEnded");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 target = new Vector2(player.position.x, player.position.y);
        Vector2 newPos = Vector2.MoveTowards(transform.position, target, speed * Time.fixedDeltaTime);

        Debug.Log("Target: " + target);
        Debug.Log("Pos: " + newPos);
    }

}
