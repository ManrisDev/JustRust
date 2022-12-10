using UnityEngine;

public class PlayerMovement : Entity
{
    [Header("Characteristics")]
    [SerializeField] private float speed = 3f; //Movement speed
    [SerializeField] private float jumpForce = 17f; //Jump power
    [SerializeField] private int lives = 100;

    [SerializeField][Range(0, 1f)] private float colliderArea = 0.3f;

    private new Rigidbody2D rigidbody;
    private Animator animator;

    private float direction;
    private bool isGrounded;
    private bool isFight;   

    private States State
    {
        get { return (States)animator.GetInteger("state"); }
        set { animator.SetInteger("state", (int)value); }
    }

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Update()
    {
        direction = Input.GetAxis("Horizontal");
        if (direction > 0)
            transform.localScale = new Vector2(-1f, 1f);
        else if (direction < 0)
            transform.localScale = new Vector2(1f, 1f);

        if (isGrounded) State = States.idle;

        if (Input.GetButton("Horizontal"))
            Walk();
        if (isGrounded && Input.GetButtonDown("Jump"))
            Jump();
    }

    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, colliderArea);
        isGrounded = collider.Length > 1;

        if (!isGrounded) State = States.jump;
    }

    private void Walk()
    {
        if (isGrounded) State = States.run;
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }

    private void Run()
    {

        if (isGrounded) State = States.run;
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        //sprite.flipX = direction.x < 0f;
    }

    private void Jump()
    {
        rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    /*public override void Take_Damage(int lost_lives)
    {
        int remaining_lives = lives - lost_lives;
        animator.SetTrigger("damage");
        while (lives > remaining_lives)
        {
            hearts[lives - 1].SetActive(false);
            lives--;
            if (lives == 0)
            {
                FindObjectOfType<GameManager>().EndGame();
                break;
            }
        }
        GlobalVar.Set_lives(lives);
        Debug.Log(lives);
    }*/

    public override void Die()
    {
        gameObject.SetActive(false);
    }
}
